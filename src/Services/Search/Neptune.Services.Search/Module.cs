using Autofac;

namespace Neptune.Services.Search
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<App>();
        }
    }
}
