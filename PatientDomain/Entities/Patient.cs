using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PatientDomain.Entities
{
    public class Patient : Auditable
    {
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]  
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]  
        public string Gender { get; set; }  

    }
}
