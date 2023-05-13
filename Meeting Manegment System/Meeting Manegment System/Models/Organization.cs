using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Organization
    {
        //artributes of organiztion
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //Relationship 
        public List<Committee> Committees { get; set; }
        

    }
}
