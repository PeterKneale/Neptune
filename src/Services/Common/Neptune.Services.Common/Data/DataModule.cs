using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptune.Services.Common.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().SingleInstance();
            //builder.Register(x => x.Resolve<IConnectionFactory>().Create()).As<IDbConnection>(); // for readonly repos

        }
    }
}
