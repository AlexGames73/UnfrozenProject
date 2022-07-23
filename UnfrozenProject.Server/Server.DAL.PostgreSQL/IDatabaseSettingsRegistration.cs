namespace Server.Database;

public interface IDatabaseSettingsRegistration
{
    void RegisterConnectionString(string connectionString);
}
