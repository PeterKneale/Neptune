using Autofac;
using AutoMapper;
using Dapper;
using EasyNetQ;
using Microsoft.Extensions.Logging;
using Neptune.Services.Common;
using Neptune.Services.Common.Bus;
using Neptune.Services.Identities.Handlers;
using Neptune.Services.Identities.Messages;

namespace Neptune.Services.Identities
{
    public class App : IService
    {
        private readonly IBus _bus;
        private readonly ILogger<App> _logger;
        private readonly IComponentContext _resolver;

        public App(IBus bus, ILogger<App> logger, IComponentContext resolver)
        {
            _bus = bus;
            _logger = logger;
            _resolver = resolver;
        }

        public void Run()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            Mapper.Initialize(x =>
            {
                x.AddProfile<Mappings>();
            });
            Mapper.AssertConfigurationIsValid();
            SetupToRespond<GetIdentityRequest, GetIdentityResponse>();
        }

        private void Setup<TCommand>()
            where TCommand : class, ICommand
        {
            _logger.LogInformation($"Setting up to handle command {typeof(TCommand).Name}");
            _bus.Receive<TCommand>(typeof(TCommand).Name, request => _resolver.Resolve<ICommandExecutor>().ExecuteCommand(request));
        }

        private void SetupToRespond<TRequest, TResponse>()
            where TRequest : class, IQuery
            where TResponse : class, IQueryResult
        {
            _logger.LogInformation($"Setting up to handle query {typeof(TRequest).Name}");
            _bus.RespondAsync<TRequest, TResponse>(request => _resolver.Resolve<IQueryExecutor>().ExecuteQuery<TRequest, TResponse>(request));
        }

        private void SetupToHandle<TEvent>()
            where TEvent : class, IEvent
        {
            _logger.LogInformation($"Setting up to handle event {typeof(TEvent).Name}");
            _bus.Subscribe<TEvent>(typeof(App).FullName, evnt => _resolver.Resolve<IEventExecutor>().ExecuteEvent(evnt));
        }
    }
}