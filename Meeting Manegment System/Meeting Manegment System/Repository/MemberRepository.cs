using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public bool Add(Member member)
        {
            _context.Add(member);
            return Save();
        }

        public bool Delete(Member member)
        {
            _context.Remove(member);
            return Save();
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved > 0 ? true : false ;
        }

        public bool Update(Member member)
        {
            _context.Update(member);
            return Save();
        }
    }
}
