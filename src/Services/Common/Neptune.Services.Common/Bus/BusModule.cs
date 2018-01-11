using System;
using Autofac;
using EasyNetQ;

namespace Neptune.Services.Common.Bus
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var bus = RabbitHutch.CreateBus("host=rabbitmq;timeout=120;product=neptune");
            builder.RegisterInstance(bus).SingleInstance();

            builder.RegisterType<Dispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<Dispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<Dispatcher>().As<IEventDispatcher>();

            builder.RegisterType<Executor>().As<ICommandExecutor>();
            builder.RegisterType<Executor>().As<IEventExecutor>();
            builder.RegisterType<Executor>().As<IQueryExecutor>();

            builder.RegisterType<Validator>().As<IValidator>();
            
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IMessageValidator<>)).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces();
        }
    }
}
