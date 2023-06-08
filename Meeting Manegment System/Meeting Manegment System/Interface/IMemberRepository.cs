using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberRepository
    {
        bool Add(Member member);
        bool Delete(Member member);
        bool Update(Member member);
        bool Save();
    }
}
