using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Committee
    {
       [Key] public int Id { get; set; }
        public string Name { get; set; }

        //Relationships
         public List<MemberCommittee> member_Committees { get; set; }
         public List<Meeting> meetings { get; set; }
        
        //Organiztion Relationship
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }


        
    }
}
