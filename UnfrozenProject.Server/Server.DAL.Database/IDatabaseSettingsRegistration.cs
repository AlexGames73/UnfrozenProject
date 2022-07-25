namespace Server.Database;

public interface IDatabaseSettingsRegistration
{
    void RegisterNpgsqlConnectionString(string connectionString);
    void RegisterSqlLiteConnectionString(string connectionString);
}
