using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class MemberAnswers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VotingId { get; set; }
        [Required]
        public int MeetingId { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int CommitteeId { get; set; }
        public Voting Voting { get; set; }
        public Meeting Meeting { get; set; }
        public Member Member { get; set; }
    }
}
