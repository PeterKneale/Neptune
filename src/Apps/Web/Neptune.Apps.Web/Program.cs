using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Gelf.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace Neptune.Apps.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TelemetryConfiguration.Active.DisableTelemetry = true;
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services => services.AddAutofac())
                .Build();
    }
}
