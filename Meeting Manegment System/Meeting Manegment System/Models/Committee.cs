using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Committee
    {
       [Key] public int Id { get; set; }
        public string Name { get; set; }

        //Relationships
         public List<MemberCommittee> MemberCommittees { get; set; }
         public List<Meeting> Meetings { get; set; }
        
        //Organiztion Relationship
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }


        
    }
}
