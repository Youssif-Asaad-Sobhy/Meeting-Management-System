using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class MemberAnswerRepository : IMemberAnswerRepository
    {
        private ApplicationDbContext _context;
        public MemberAnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(MemberAnswers memberAnswers)
        {
            _context.Add(memberAnswers);
            return Save();
        }

        public bool Delete(MemberAnswers memberAnswers)
        {
            _context.Remove(memberAnswers);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        public bool Update(MemberAnswers memberAnswers)
        {
            _context.Update(memberAnswers);
            return Save();
        }
    }
}
