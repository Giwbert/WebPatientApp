using Microsoft.AspNetCore.Mvc;
using WebPatientApp.Repositories.Abstract;

namespace WebPatientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientService _patientService;
        public HomeController(IPatientService PatientService)
        {
            _patientService = PatientService;
        }
        public IActionResult Index(string term="", int currentPage = 1)
        {
            var patients = _patientService.List(term,true,currentPage);
            return View(patients);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult PatientDetail(int patientId)
        {
            var patient = _patientService.GetById(patientId);
            return View(patient);
        }

    }
}
