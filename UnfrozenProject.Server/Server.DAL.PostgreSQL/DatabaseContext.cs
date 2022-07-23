using Microsoft.EntityFrameworkCore;
using Server.Database.Models;

namespace Server.Database;

internal sealed class DatabaseContext : DbContext
{
    private static bool _migrated;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        if (!Database.IsRelational())
        {
            Database.EnsureCreated();
            return;
        }
        if (_migrated) return;

        Database.Migrate();
        _migrated = true;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
}
