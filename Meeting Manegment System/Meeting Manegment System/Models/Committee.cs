using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Committee
    {
        [Key]
        public int CommitteeId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public Organization Organization { get; set; }
        public List<MemberCommittee> MemberCommittees { get; set; }
        public List<Meeting> Meetings { get; set; }


        
    }
}
