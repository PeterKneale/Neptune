using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Neptune.Apps.Web.Models;
using Neptune.Apps.Web.Services;
using Neptune.Services.Common.Bus;
using Neptune.Services.Identities.Messages;
using Neptune.Services.Profiles.Messages;

namespace Neptune.Apps.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService users;

        public UserController(IUserService users)
        {
            this.users = users;
        }
        
        public async Task<IActionResult> Index(Guid id)
        {
            var user = await users.Get(id);

            var page = new UserPageViewModel
            {
                User = user
            };

            return View(page);
        }
    }
}
