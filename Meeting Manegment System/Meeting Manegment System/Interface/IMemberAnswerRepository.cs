using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberAnswerRepository
    {
        bool Save();
        bool Delete(MemberAnswers memberAnswers);
        bool Update(MemberAnswers memberAnswers);
        bool Add (MemberAnswers memberAnswers);
    }
}
