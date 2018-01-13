using Autofac;
using Microsoft.Extensions.Logging;
using Gelf.Extensions.Logging;
using System;

namespace Neptune.Services.Common.Logging
{
    public class LogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var name = AppDomain.CurrentDomain.FriendlyName;
            var factory = new LoggerFactory()
                .AddDebug()
                .AddConsole(true)
                .AddGelf(new GelfLoggerOptions
                {
                    Host = "graylog",
                    LogSource = name,
                    LogLevel = LogLevel.Information,
                    Port = 12201,

                }); 
            builder.RegisterInstance(factory).As<ILoggerFactory>().SingleInstance();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
        }
    }
}
