using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mvc1LoginDemo.Controllers
{
    public class RefereeController : Controller
    {

        [Authorize(Roles = "RefAdmin,Admin")]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "RefAdmin,Admin")]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize(Roles = "RefAdmin,Admin")]
        public IActionResult New()
        {
            return View();
        }

    }
}