using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Neptune.Apps.Web.Models;
using Neptune.Services.Common.Bus;
using Neptune.Services.Profiles.Messages;

namespace Neptune.Apps.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IQueryDispatcher _queries;

        public UserController(IQueryDispatcher queries)
        {
            _queries = queries;
        }
        
        public async Task<IActionResult> Index(Guid id)
        {
            var response = await _queries.Request<GetProfileRequest, GetProfileResponse>(new GetProfileRequest { Id = id });
            var profile = response.Profile;

            if(profile == null)
            {
                return NotFound();
            }
            
            var page = new UserPageViewModel
            {
                Profile = Mapper.Map<ProfileDto, UserViewModel>(profile)
            };
            return View(page);
        }
    }
}
