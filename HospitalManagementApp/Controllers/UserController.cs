using CommonLayer;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([Bind] UserLoginModel login)
        {
            if (ModelState.IsValid)
            {
                var res=userManager.Login(login);
                if (res != null)
                {
                    HttpContext.Session.SetInt32("userId", res.UserId);
                    //HttpContext.Session.SetString("Email", res.Email);
                    HttpContext.Session.SetInt32("RoleId", res.RoleId);
                    if (res.RoleId == 3)
                    {
                        return RedirectToAction("GetPatientByUserId", "Patient");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(login);
        }
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            List<UserRegistrationModel> list = new List<UserRegistrationModel>();
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
            if (roleId == 1)
            {
                list = userManager.GetAllRecords().ToList();
                return View(list);
            }
            return RedirectToAction("Login", "User");
        } 
    }
}
