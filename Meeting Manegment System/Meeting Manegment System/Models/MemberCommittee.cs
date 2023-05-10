using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class MemberCommittee
    {
        private const int V = 1;

        [Key, Column(Order = 0)]
        public int CommitteeId { get; set; }
        public Committee committee { get; set; }

        [Key, Column(Order = V)]
        public int MemberId { get; set; }
       public Member Member { get; set; }
       
        public string Role { get; set; }

    }
}
