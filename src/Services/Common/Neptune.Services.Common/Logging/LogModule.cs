using System.Data;
using Autofac;
using Microsoft.Extensions.Logging;

namespace Neptune.Services.Common.Logging
{
    public class LogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var factory = new LoggerFactory()
                .AddConsole(LogLevel.Information)
                .AddDebug();

            
            builder.RegisterInstance(factory).As<ILoggerFactory>().SingleInstance();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
        }
    }
}
