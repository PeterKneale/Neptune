using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Logging;
using Polly;
using System;

namespace Neptune.Services.Common.ServiceHost
{
    public interface IServiceHost<TModule, TApp>
            where TModule : IModule, new()
            where TApp : IService
    {
        void Host();
    }

    public class ServiceHost<TModule, TApp> : IServiceHost<TModule, TApp>
            where TModule : IModule, new()
            where TApp : IService
    {
        private const int RetriesBeforeExit = 5;

        private readonly ILogger<TApp> _log;

        public ServiceHost(ILogger<TApp> log)
        {
            _log = log;
        }

        public void Host()
        {
            _log.LogInformation($"Service {typeof(TApp).FullName} starting");

            // Setup the container for the actual service
            var builder = new ContainerBuilder();
            builder.RegisterModule<TModule>();
            Start(builder.Build().Resolve<TApp>());

            _log.LogWarning($"Service {typeof(TApp).FullName} started");
        }

        private void Start(IService app)
        {
            var policy = Policy
              .Handle<Exception>()
              .Retry(RetriesBeforeExit, (exception, context) =>
              {
                  _log.LogError(exception, $"Error during execution of {typeof(IService).Name}");
              });
            policy.Execute(() => app.Run());
        }
    }
}
