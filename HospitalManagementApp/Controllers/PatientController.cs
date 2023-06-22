using CommonLayer;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
        public IActionResult GetPatientbyId()
        {
            if (ModelState.IsValid)
            {
                PatientModel patient = new PatientModel();
                HttpContext.Session.SetInt32("PatientId", patient.PatientId);
                int patientId = (int)HttpContext.Session.GetInt32("PatientId");
                var res = patientManager.GetPatientbyId(patientId);
                return View(res);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
