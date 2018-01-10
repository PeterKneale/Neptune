using Autofac;
using Autofac.Core;
using Neptune.Services.Common;
using System.Threading.Tasks;

namespace Neptune.Services.MultiHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = Task.Run(() => Run<Databases.Module, Databases.App>());
            System.Threading.Thread.Sleep(2000);
            var profile = Task.Run(() => Run<Profiles.Module, Profiles.App>());
            Task.WaitAll(database, profile);
        }

        private static void Run<TModule, TApp>()
            where TModule : IModule, new()
            where TApp : IRun
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<TModule>();
            builder.Build().Resolve<TApp>().Run();
        }
    }
}
