using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientDomain.Entities;
using WebPatientApp.Repositories.Abstract;

namespace WebPatientApp.Controllers
{
    [Authorize]
    public class PatientAppController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientAppController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public IActionResult Add()
        {
            var model = new Patient();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Patient model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _patientService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var model = _patientService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Patient model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _patientService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(PatientList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult PatientList()
        {
            var data = this._patientService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _patientService.Delete(id);
            return RedirectToAction(nameof(PatientList));
        }



    }
}
