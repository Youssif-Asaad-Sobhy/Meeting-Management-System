using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.ViewModels
{
    public class VotingView
    {
        public List<Voting> Votings { get; set; }
        public List<MemberAnswers> MemberAnswers { get; set; }
        public RoleType Role { get; set; }
        public int MeetingId { get; set; }
    }
}
