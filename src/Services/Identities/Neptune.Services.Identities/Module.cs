using Autofac;

namespace Neptune.Services.Identities
{
    public class Module: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<App>();
        }
    }
}
