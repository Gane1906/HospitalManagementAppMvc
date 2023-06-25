using CommonLayer;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace HospitalManagementApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientManager patientManager;
        public PatientController(IPatientManager patientManager)
        {
            this.patientManager = patientManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddPatientDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPatientDetails([Bind] PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                patientManager.AddPatientDetails(patient);
                return RedirectToAction("Index", "Home");
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult GetPatientbyId(int PatientId)
        {
            if (ModelState.IsValid)
            {
                PatientId = (int)HttpContext.Session.GetInt32("PatientId");
                var res = patientManager.GetPatientbyId(PatientId);
                return View(res);
            }
            return RedirectToAction("Login", "User ");
        }
        [HttpGet]
        public IActionResult GetPatientByUserId()
        {
            if (ModelState.IsValid)
            {
                int userId = (int)HttpContext.Session.GetInt32("userId");
                var res = patientManager.GetPatientByUserId(userId);
                return View(res);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult GetAllpatients()
        {
            if (ModelState.IsValid)
            {
                int RoleId = (int)HttpContext.Session.GetInt32("RoleId");
                if (RoleId == 2)
                {
                    List<PatientModel> list = new List<PatientModel>();
                    list = patientManager.GetAllPatients();
                    foreach (PatientModel item in list)
                    {
                        HttpContext.Session.SetInt32("PatientId", item.PatientId);
                    }
                    return View(list);
                }
                
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
