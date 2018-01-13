using Autofac;

namespace Neptune.Services.Discussions
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<App>();
        }
    }
}
