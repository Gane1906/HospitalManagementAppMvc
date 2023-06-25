using CommonLayer;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;

namespace HospitalManagementApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorManager doctorManager;
        public DoctorController(IDoctorManager doctorManager)
        {
            this.doctorManager = doctorManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddDoctorDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDoctorDetails([Bind] DoctorModel doctor)
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            if (ModelState.IsValid)
            {
                doctorManager.AddDoctorDetails(doctor);
                return RedirectToAction("Index", "Home");
            }
            return View(doctor);
        }
        [HttpGet]
        public IActionResult GetDoctorById()
        {
            if (ModelState.IsValid)
            {
                int doctorId = (int)HttpContext.Session.GetInt32("DoctorId");
                var res = doctorManager.GetDoctorById(doctorId);
                return View(res);
            }
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult GetDoctorByUserId()
        {
            if (ModelState.IsValid)
            {
                int userId = (int)HttpContext.Session.GetInt32("userId");
                var res = doctorManager.GetDoctorByUserId(userId);
                if (res != null)
                {
                    HttpContext.Session.SetInt32("DoctorId", res.DoctorId);
                    return View(res);
                }
                
            }
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            if (ModelState.IsValid)
            {
                int roleId = (int)HttpContext.Session.GetInt32("RoleId");
                if (roleId == 3)
                {
                    List<DoctorModel> list = new List<DoctorModel>();
                    list = doctorManager.GetAllDoctors();
                    foreach(DoctorModel item in list)
                    {
                        HttpContext.Session.SetInt32("DoctorId", item.DoctorId);
                    }
                    return View(list);
                }
            }
            return RedirectToAction("Login", "User");
        }
    }
}
