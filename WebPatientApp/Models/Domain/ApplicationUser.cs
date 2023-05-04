using Microsoft.AspNetCore.Identity;

namespace WebPatientApp.Models.Domain
{   
    public class ApplicationUser : IdentityUser
    {
        public string Name{ get; set; }
    }
}
