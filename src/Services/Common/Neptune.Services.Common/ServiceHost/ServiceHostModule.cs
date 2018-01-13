using Autofac;
using Autofac.Core;
using Neptune.Services.Common.Logging;

namespace Neptune.Services.Common.ServiceHost
{
    public class ServiceHostModule<TModule, TApp> : Module
            where TModule : IModule, new()
            where TApp : IService
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<LogModule>();
            builder.RegisterType<ServiceHost<TModule, TApp>>().As<IServiceHost<TModule, TApp>>();
        }
    }
}
