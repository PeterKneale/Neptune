using Autofac;
using Neptune.Services.Common.ServiceHost;

namespace Neptune.Services.Databases
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceHostModule<Module, App>>();
            var container = builder.Build();
            container.Resolve<IServiceHost<Module, App>>().Host();
        }
    }
}
