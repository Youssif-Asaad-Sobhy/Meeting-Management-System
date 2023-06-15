using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.ViewModels
{
    public class CommitteeMembersView
    {
        public CommitteeMembersView() 
        { 
            Member=new Member();
            members = new List<MemberCommittee>();
        }
        public Member Member { get; set; }
        public List<MemberCommittee> members { get; set; }
    }
}
