using System.ComponentModel.DataAnnotations;

namespace Meeting_Manegment_System.Models
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }

        public string Goals { get; set; }
        public DateTime Date { get; set;}= DateTime.Now;
        public bool Emergency { get; set; }

        //Relationships
         public List<Report> Reports { get; set; }
         public List<Voting> Votings { get; set; }
         public List<MemberAnswers> MemberAnswers { get; set; }

        //committee Relationship
        public int CommitteeId { get; set; }
        public Committee Committee { get; set; }
       

    }
    
}
