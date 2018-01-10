namespace Neptune.Services.Databases
{
    public interface IConfig
    {
        string QuestionsConnectionString { get; }
        string MasterConnectionString { get; }
        string ProfilesConnectionString { get; }
    }

    public class Config : IConfig
    {
        public string QuestionsConnectionString => "Server=.;Database=questions;User id=sa;Password=password;MultipleActiveResultSets=true";
        public string ProfilesConnectionString => "Server=.;Database=profiles;User id=sa;Password=password;MultipleActiveResultSets=true";
        public string MasterConnectionString => "Server=.;Database=master;User id=sa;Password=password;MultipleActiveResultSets=true";
    }
}
