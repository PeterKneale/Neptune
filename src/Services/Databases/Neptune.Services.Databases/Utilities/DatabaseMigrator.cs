using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Neptune.Services.Databases
{
    public interface IDatabaseMigrator
    {
        void Migrate(string connectionString, Assembly assembly);
    }

    public class DatabaseMigrator : IDatabaseMigrator
    {
        private readonly ILogger<DatabaseMigrator> _log;

        public DatabaseMigrator(ILogger<DatabaseMigrator> log)
        {
            _log = log;
        }

        public void Migrate(string connectionString, Assembly assembly)
        {
            var announcer = new TextWriterAnnouncer(s => _log.LogInformation(s));
            var migrationContext = new RunnerContext(announcer);
            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60, ProviderSwitches = string.Empty };
            var factory = new SqlServerProcessorFactory();
            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateDown(0);
                runner.MigrateUp(true);
            }
        }
    }

    class MigrationOptions : IMigrationProcessorOptions
    {
        public bool PreviewOnly { get; set; }
        public string ProviderSwitches { get; set; }
        public int Timeout { get; set; }
    }
}
