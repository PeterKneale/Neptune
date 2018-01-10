using Neptune.Services.Questions.Database;
using Neptune.Services.Profiles.Database;
using System;
using Neptune.Services.Common;

namespace Neptune.Services.Databases
{
    public class App : IRun
    {
        private readonly IConfig _config;
        private readonly IDatabaseCreator _creator;
        private readonly IDatabaseMigrator _migrator;

        public App(IConfig config, IDatabaseCreator creator, IDatabaseMigrator migrator)
        {
            _config = config;
            _creator = creator;
            _migrator = migrator;
        }

        public void Run()
        {
            Provision(_config.QuestionsConnectionString, typeof(Questions.Database.DatabaseSchema));
            Provision(_config.ProfilesConnectionString, typeof(Profiles.Database.DatabaseSchema));
        }

        private void Provision(string connection, Type migration)
        {
            var assembly = System.Reflection.Assembly.GetAssembly(migration);
            _creator.Create(_config.MasterConnectionString, connection);
            _migrator.Migrate(connection, assembly);
        }
    }
}
