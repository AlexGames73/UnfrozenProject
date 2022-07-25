using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Server.Database;

internal class DatabaseContextFactoryDesignTime : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=unfrozen-project;User id=postgres;Password=postgres;");
        optionsBuilder.UseSqlite("Data Source=UnfrozenDatabase.sqlite;");

        return new DatabaseContext(optionsBuilder.Options);
    }
}
