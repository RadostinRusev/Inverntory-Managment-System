using Inverntory_Managment_System.DataAccess;
using Inverntory_Managment_System.Entity;
using Inverntory_Managment_System.Models;
using Inverntory_Managment_System.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Login()
        {
                

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
    
            if (!ModelState.IsValid)
                return View(model);

            InventoryDbContext context = new InventoryDbContext();
            User loggedUser = context.Users.Where(u => u.Username == model.Username &&
                                                       u.Password == model.Password)
                                           .FirstOrDefault();

            if (loggedUser == null)
            {
                ModelState.AddModelError("AuthenticationFailed", "Wrong username or password");
                return View(model);
            }

            this.HttpContext.Session.SetString("LoggedUserId", loggedUser.Id.ToString());
            this.HttpContext.Session.SetString("LoggedUserUsername", loggedUser.Username);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("LoggedUserId");

            return RedirectToAction("Index", "Home");
        }
    }
}
