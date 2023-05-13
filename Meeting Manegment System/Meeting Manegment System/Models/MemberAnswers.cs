using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class MemberAnswers
    {
        [Key, Column(Order = 0)]
        public int VotingId { get; set; }
        public Voting? Voting { get; set; }  
        [Key, Column(Order = 1)]
        public int MeetingId { get; set; }
        public Meeting? Meeting { get; set; }
        [Key, Column(Order = 2)]
        public int MemberId { get; set; }
        public Member? Member { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
