using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class MemberCommittee
    {
        [Key]
        public int CommitteeId { get; set; }
        [Key]
        public int MemberId { get; set; }
        public string? Role { get; set; }
        public Committee? Committee { get; set; }
        public Member? Member { get; set; }

    }
}
