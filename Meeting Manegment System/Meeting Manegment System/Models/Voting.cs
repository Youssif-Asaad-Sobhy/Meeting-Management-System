using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Manegment_System.Models
{
    public class Voting
    {
        [Key]
        public int VotingId { get; set; }
        [Key]
        public int MeetingId { get; set; }
        public string Question { get; set; }
        public List<MemberAnswers> MemberAnswers { get; set; }
        public Meeting Meeting { get; set; }


    }
}
