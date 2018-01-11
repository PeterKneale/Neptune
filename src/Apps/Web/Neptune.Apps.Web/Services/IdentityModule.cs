using Autofac;
using Microsoft.AspNetCore.Identity;
using Neptune.Apps.Web.Models;

namespace Neptune.Apps.Web
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserStore>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<RoleStore>().As<IRoleStore<ApplicationRole>>();
        }
    }
}
