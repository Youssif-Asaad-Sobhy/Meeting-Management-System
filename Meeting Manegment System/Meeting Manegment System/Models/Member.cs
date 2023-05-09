using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Member
    {
        [Key]
        public int SSN { get; set; }
        [Required]
        //Attributes
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Password { get; set; }

        //Relations
        public List<MemberAnswers> MemberAnswers { get; set; }
    }
}
