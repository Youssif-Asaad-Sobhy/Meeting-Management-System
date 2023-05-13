using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class Report
    {
        private const int V = 1;

        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Description { get; set; }

        //Relationships

        //Meeting Relationship
        [Key, Column(Order = V)]
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
