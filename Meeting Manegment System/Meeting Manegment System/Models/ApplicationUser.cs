using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name ="Full name")]
        public string FullName { get; set; }
         
    }
}
