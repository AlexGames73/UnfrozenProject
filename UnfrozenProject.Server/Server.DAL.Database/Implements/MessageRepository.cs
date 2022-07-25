using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.Repositories;
using Server.DAL.Logic.ViewModels;
using Server.Database.Models;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Server.Database.Implements;

[Dependency]
public class MessageRepository : IMessageRepository
{
    private readonly IDatabaseSettingsProvider _databaseSettingsProvider;

    public async Task<Guid> CreateOrUpdateAsync(MessageBinding model)
    {
        await using var context = _databaseSettingsProvider.CreateDbContext();
        var message = context.Messages.FirstOrDefault(x => x.Id == model.Id);
        if (message == null)
        {
            message = new Message { Created = DateTime.UtcNow };
            context.Messages.Add(message);
        }

        message.Content = model.Content;
        message.FromId = model.FromUserId;
        message.ToId = model.ToUserId;
        message.Updated = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return message.Id;
    }

    public async Task<PageView<MessageView>> ReadAsync(MessageFilterBinding filter, PageBinding page)
    {
        await using var context = _databaseSettingsProvider.CreateDbContext();

        var queryable = MakeFilter(context, filter)
            .Include(x => x.From)
            .Include(x => x.To)
            .AsNoTracking();
        var totalCount = await queryable.CountAsync();
        var messages = await queryable
            .OrderByDescending(x => x.Created)
            .Skip(page.Offset)
            .Take(page.Count)
            .Select(x => new MessageView
            {
                Id = x.Id,
                Content = x.Content,
                FromUser = new UserView
                {
                    Id = x.FromId,
                    Color = Color.FromArgb(x.From.Color),
                    Username = x.From.Username
                },
                ToUser = new UserView
                {
                    Id = x.ToId,
                    Color = Color.FromArgb(x.To.Color),
                    Username = x.To.Username
                },
                DateTime = x.Created
            })
            .ToArrayAsync();
        return new PageView<MessageView>
        {
            TotalCount = totalCount,
            Elements = messages
        };
    }

    public async Task DeleteAsync(MessageFilterBinding filter)
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

    private static IQueryable<Message> MakeFilter(DatabaseContext context, MessageFilterBinding filter)
    {
        return context.Messages
            .Where(x => filter.Query == null || EF.Functions.ILike(x.Content, filter.Query))
            .Where(x => filter.FromUserIds.Count == 0 || filter.FromUserIds.Contains(x.FromId))
            .Where(x => filter.ToUserIds.Count == 0 || filter.ToUserIds.Contains(x.ToId));
    }
}
