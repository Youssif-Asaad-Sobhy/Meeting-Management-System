using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Committee> Committees { get; set; }
        

    }
}
