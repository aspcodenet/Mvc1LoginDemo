using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Mvc1LoginDemo.Controllers
{
    public class PlayerController : Controller
    {

        [Authorize(Roles= "PlayerAdmin,Admin,RefAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        
        [Authorize(Roles = "PlayerAdmin,Admin")]
        public IActionResult Edit()
        {


            return View();
        }

        [Authorize(Roles = "PlayerAdmin,Admin")]
        public IActionResult New()
        {
            return View();
        }

    }
}
