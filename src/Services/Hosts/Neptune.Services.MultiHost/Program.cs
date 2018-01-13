using Autofac;
using Neptune.Services.Common.Logging;
using System.Threading;

namespace Neptune.Services.MultiHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterModule<LogModule>();
            //builder.RegisterType<ServiceHost>().As<IServiceHost>();
            //var container = builder.Build();
            //var host = container.Resolve<IServiceHost>();

            //host.Run<Profiles.Module, Profiles.App>();
            //host.Run<Databases.Module, Databases.App>();
            //host.Run<Questions.Module, Questions.App>();
            //host.Run<Search.Module, Search.App>();
            //host.Run<Discussions.Module, Discussions.App>();
            //host.Run<Identities.Module, Identities.App>();

            //Thread.Sleep(Timeout.Infinite);
        }
    }
}
