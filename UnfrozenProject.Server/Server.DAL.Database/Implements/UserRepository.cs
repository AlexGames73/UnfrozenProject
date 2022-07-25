using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.Repositories;
using Server.DAL.Logic.ViewModels;
using Server.Database.Models;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Server.Database.Implements;

[Dependency]
public class UserRepository : IUserRepository
{
    private readonly IDatabaseSettingsProvider _databaseSettingsProvider;
    
    public async Task<Guid> CreateOrUpdateAsync(UserBinding model)
    {
        await using var context = _databaseSettingsProvider.CreateDbContext();
        var user = context.Users.FirstOrDefault(x => x.Username == model.Username);
        if (user == null)
        {
            user = new User { Created = DateTime.UtcNow };
            context.Users.Add(user);
        }

        user.Username = model.Username;
        user.Color = model.Color.ToArgb();
        user.Updated = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<PageView<UserView>> ReadAsync(UserFilterBinding? filter, PageBinding? page)
    {
        await using var context = _databaseSettingsProvider.CreateDbContext();

        var queryable = MakeFilter(context, filter).AsNoTracking();
        var totalCount = await queryable.CountAsync();

        if (page != null && page.Count != 0)
        {
            queryable = queryable
                .Skip(page.Offset)
                .Take(page.Count);
        }
        
        var users = await queryable
            .Select(x => new UserView
            {
                Id = x.Id,
                Username = x.Username,
                Color = Color.FromArgb(x.Color)
            })
            .ToArrayAsync();
        
        return new PageView<UserView>
        {
            TotalCount = totalCount,
            Elements = users
        };
    }

    public async Task DeleteAsync(UserFilterBinding? filter)
    {
        await using var context = _databaseSettingsProvider.CreateDbContext();

        var users = await MakeFilter(context, filter).ToListAsync();
        users.ForEach(x =>
        {
            x.Updated = DateTime.UtcNow;
            x.Deleted = true;
        });
        await context.SaveChangesAsync();
    }

    private static IQueryable<User> MakeFilter(DatabaseContext context, UserFilterBinding? filter)
    {
        if (filter == null)
        {
            return context.Users.Where(x => !x.Deleted);
        }
        
        var colorsInts = filter.Colors.Select(x => x.ToArgb()).ToArray();
        return context.Users
            .Where(x => filter.UserIds.Count == 0 || filter.UserIds.Contains(x.Id))
            .Where(x => filter.Usernames.Count == 0 || filter.Usernames.Contains(x.Username))
            .Where(x => colorsInts.Length == 0 || colorsInts.Contains(x.Color))
            .Where(x => filter.IncludeDeleted || !x.Deleted);
    }
}
