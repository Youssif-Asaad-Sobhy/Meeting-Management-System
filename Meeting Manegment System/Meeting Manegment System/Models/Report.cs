using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string Description { get; set; }
        [Required]  
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
