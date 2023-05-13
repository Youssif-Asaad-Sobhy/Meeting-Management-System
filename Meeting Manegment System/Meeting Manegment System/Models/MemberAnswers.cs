using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class MemberAnswers
    {
        public int VotingId { get; set; }
        public int MeetingId { get; set; }
        public int MemberId { get; set; }
        public Voting? Voting { get; set; }
        public Meeting? Meeting { get; set; }
        public Member? Member { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
