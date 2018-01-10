using Autofac;
using Neptune.Services.Common.Bus;
using Neptune.Services.Common.Logging;

namespace Neptune.Services.Databases
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusModule>();
            builder.RegisterModule<LogModule>();

            builder.RegisterType<Config>().As<IConfig>();
            builder.RegisterType<DatabaseCreator>().As<IDatabaseCreator>();
            builder.RegisterType<DatabaseMigrator>().As<IDatabaseMigrator>();
            builder.RegisterType<App>();
        }
    }
}
