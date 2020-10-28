using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleUT.Areas.Identity.Pages.Account;
using VehicleUT.Models;

namespace VehicleUT.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager) {
            _logger = logger;
            this.signInManager = signInManager;
        }

        public IActionResult Index() {
            if (signInManager.IsSignedIn(HttpContext.User)) 
                return RedirectToAction("Index","Vehicle");
            else
                return LocalRedirect("/Identity/Account/Login");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
