namespace Neptune.Services.Databases
{
    public interface IConfig
    {
        string QuestionsConnectionString { get; }
        string MasterConnectionString { get; }
        string ProfilesConnectionString { get; }
        string IdentitiesConnectionString { get; }
    }

    public class Config : IConfig
    {
        private const string host = "sql";
        private const string username = "sa";
        private const string password = "Password123%";
        private const string port = "1433";
        public string MasterConnectionString => $"Server={host},{port};Database=master;User id={username};Password={password};MultipleActiveResultSets=true";

        public string QuestionsConnectionString => $"Server={host},{port};Database=questions;User id={username};Password={password};MultipleActiveResultSets=true";
        public string ProfilesConnectionString => $"Server={host},{port};Database=profiles;User id={username};Password={password};MultipleActiveResultSets=true";
        public string IdentitiesConnectionString => $"Server={host},{port};Database=identities;User id={username};Password={password};MultipleActiveResultSets=true";
    }
}
