namespace Server.Database;

internal interface IDatabaseSettingsProvider : IDatabaseSettingsRegistration
{
    DatabaseContext CreateDbContext();
}
