using CommonLayer;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind] UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                userManager.Registration(model);
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
    }
}
