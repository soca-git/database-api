namespace Database.Bootstrap.Configuration
{
    public interface IAppConfiguration
    {
        string GetDatabaseConnectionString();
    }
}
