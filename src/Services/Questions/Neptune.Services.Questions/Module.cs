using Autofac;
using Neptune.Services.Common.Bus;
using Neptune.Services.Common.Data;
using Neptune.Services.Common.Logging;
using Neptune.Services.Questions.Data;
using System.Data;

namespace Neptune.Services.Questions
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<BusModule>();
            builder.RegisterModule<LogModule>();
            builder.RegisterModule<DataModule>();

            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().SingleInstance();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory<IQuestionUnitOfWork>>().SingleInstance();
            builder.RegisterType<QuestionSource>().As<IQuestionSource>();

            builder.Register(x => x.Resolve<IConnectionFactory>().Open()).As<IDbConnection>();

            builder.RegisterType<App>();
        }
    }
}
