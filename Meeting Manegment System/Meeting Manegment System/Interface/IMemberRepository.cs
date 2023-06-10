using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberRepository
    {
        Member GetMemberById(int id);
        Member IsMember(Member member);
        bool Add(Member member);
        bool Delete(Member member);
        bool Update(Member member);
        bool Save();
    }
}
