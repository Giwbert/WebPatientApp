using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientApplication.Interface;
using PatientApplication.ViewModels;
using PatientDomain.Entities;

namespace Patient.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IService<PatientViewModel> _patientService;

        public PatientController(ILogger<PatientController> logger, IService<PatientViewModel>? patientService)
        {
            _patientService = patientService;
            _logger = logger;
        }


        // GET: PatientController
        [HttpGet(Name = "GetPatients")]
        public async Task<IEnumerable<PatientDomain.Entities.Patient>> Get()
       {
            var model = await _patientService.GetAll();
            return (model.Patients);
        }

        [HttpPost]
        public async Task<PatientViewModel> Create(PatientDomain.Entities.Patient patient)
        {
                //var patient = new PatientDomain.Entities.Patient() { Name = Name, DOB = Dob, Age = age };
                var patientViewModel = new PatientViewModel() { NewPatient = patient } ;
                var result= await  _patientService.Add(patientViewModel);
                return result;
        }

        [HttpPut]
        public async Task<PatientViewModel> Update(PatientDomain.Entities.Patient patient)
        {
            //var patient = new PatientDomain.Entities.Patient() { Name = Name, DOB = Dob, Age = age };
            var patientViewModel = new PatientViewModel() { NewPatient = patient };
            var result = await _patientService.Update(patientViewModel);
            return result;
        }

        [HttpDelete]
        public async Task<PatientViewModel> Delete(PatientDomain.Entities.Patient patient)
        {
            //var patient = new PatientDomain.Entities.Patient() { Name = Name, DOB = Dob, Age = age };
            var patientViewModel = new PatientViewModel() { NewPatient = patient };
            var result = await _patientService.Delete(patientViewModel);
            return result;
        }

    }
}
