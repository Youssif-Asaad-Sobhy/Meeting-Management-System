using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class Voting
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Question { get; set; }

        //Relationships
         public List<MemberAnswers> MemberAnswers { get; set; }
        //member Relationships
        [Key, Column(Order = 1)]
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }


    }
}
