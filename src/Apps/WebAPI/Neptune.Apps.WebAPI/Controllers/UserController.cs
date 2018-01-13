using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neptune.Apps.WebAPI.Models;
using Neptune.Services.Common.Bus;
using Neptune.Services.Profiles.Messages;

namespace Neptune.Apps.WebAPI.Controllers
{
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IQueryDispatcher _queries;

        public UserController(IQueryDispatcher queries)
        {
            _queries = queries;
        }

        // GET api/v1/user/C084EFA3-D735-A430-A4F2-6919586A491F
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queries.Request<GetProfileRequest, GetProfileResponse>(new GetProfileRequest { Id = id });
            if (response.Profile == null)
            {
                return NotFound();
            }

            var model = new UserModel { Id = response.Profile.Id, Name = response.Profile.Name };
            return Json(model);
        }
    }

}
