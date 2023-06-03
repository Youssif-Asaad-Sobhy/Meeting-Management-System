using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int MeetingId { get; set; }
        public string Description { get; set; }
        public Meeting Meeting { get; set; }
    }
}
