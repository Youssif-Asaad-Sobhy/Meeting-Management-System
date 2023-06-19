using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Meeting_Manegment_System.Models
{
    public enum RoleType
    {
        Admin,
        Member,
        Vice,
        Secretary,
        President
    }
    public class MemberCommittee
    {
        [Key]
        public int Id { get; set; }
        public int CommitteeId { get; set; }
        public int MemberId { get; set; }
        public RoleType Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Committee Committee { get; set; }
        public Member Member { get; set; }

    }
}
