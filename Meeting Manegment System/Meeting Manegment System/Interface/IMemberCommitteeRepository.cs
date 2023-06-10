using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberCommitteeRepository
    {
        List<Committee> GetCommitteesByMemberId(int memberId);
        bool Add(MemberCommittee memberCommittee); 
        bool Delete(MemberCommittee memberCommittee);
        bool Update(MemberCommittee memberCommittee);
        bool Save();
    }
}
