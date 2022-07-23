using Microsoft.EntityFrameworkCore;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Server.Database;

[Dependency]
internal class DatabaseSettingsProvider : IDatabaseSettingsProvider
{
    public void RegisterConnectionString(string connectionString)
    {
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        builder.UseNpgsql(connectionString);
        Options = builder.Options;
    }

    public DatabaseContext CreateDbContext()
    {
        return new DatabaseContext(Options);
    }

    public DbContextOptions<DatabaseContext> Options { get; private set; }
}
