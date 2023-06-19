using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberRepository
    {
        Member GetMemberByEmail(string Email);
        Member GetMemberById(int id);
        List<Member> GetMembersExeptId(int Id);
        Member IsMember(Member member);
        bool Add(Member member);
        bool Delete(Member member);
        bool Update(Member member);
        bool Save();
    }
}
