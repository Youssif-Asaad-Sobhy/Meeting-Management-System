using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberCommitteeRepository
    {
        List<MemberCommittee> GetMembersInCommittee(int CommitteeId);
        List<Committee> GetCommitteesByMemberId(int memberId);
        RoleType GetRoleTypeById(int MemberId,int CommitteeId);
        bool Add(MemberCommittee memberCommittee); 
        bool Delete(MemberCommittee memberCommittee);
        bool Update(MemberCommittee memberCommittee);
        bool Save();
    }
}
