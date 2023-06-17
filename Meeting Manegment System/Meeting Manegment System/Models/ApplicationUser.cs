using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name ="Full Name")]
        public string? FullName { get; set; }
         
    }
}
