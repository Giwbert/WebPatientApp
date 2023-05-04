using PatientDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.ViewModels
{
    public class PatientViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public Patient? NewPatient { get; set; }
        public DateTime CurrentDate { get; set; }

    }
}
