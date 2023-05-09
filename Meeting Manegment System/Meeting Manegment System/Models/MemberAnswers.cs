using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class MemberAnswers
    {
        [Key, Column(Order = 0)]
        public int VotingId { get; set; }
        [Key, Column(Order = 1)]
        public int MeetingId { get; set; }
        [Key, Column(Order = 2)]
        public int SSN { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
