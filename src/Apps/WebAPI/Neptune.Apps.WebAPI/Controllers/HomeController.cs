using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Neptune.Apps.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
