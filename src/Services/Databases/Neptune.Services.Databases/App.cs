using Neptune.Services.Questions.Database;
using Neptune.Services.Profiles.Database;
using System;
using Neptune.Services.Common;
using Microsoft.Extensions.Logging;

namespace Neptune.Services.Databases
{
    public class App : IService
    {
        private readonly ILogger<App> _log;
        private readonly IConfig _config;
        private readonly IDatabaseCreator _creator;
        private readonly IDatabaseMigrator _migrator;

        public App(ILogger<App> log, IConfig config, IDatabaseCreator creator, IDatabaseMigrator migrator)
        {
            _log = log;
            _config = config;
            _creator = creator;
            _migrator = migrator;
        }
        

        public void Run()
        {
            Provision(_config.QuestionsConnectionString, typeof(Questions.Database.DatabaseSchema));
            Provision(_config.ProfilesConnectionString, typeof(Profiles.Database.DatabaseSchema));
            Provision(_config.IdentitiesConnectionString, typeof(Identities.Database.DatabaseSchema));
        }

        private void Provision(string connection, Type migration)
        {
            _log.LogInformation($"Provisioning {migration.FullName}");
            var assembly = System.Reflection.Assembly.GetAssembly(migration);

            _log.LogInformation($"Creating db");
            _creator.Create(_config.MasterConnectionString, connection);

            _log.LogInformation($"Migrating db");
            _migrator.Migrate(connection, assembly);

            _log.LogInformation($"Provisioned {migration.FullName}");
        }
    }
}
