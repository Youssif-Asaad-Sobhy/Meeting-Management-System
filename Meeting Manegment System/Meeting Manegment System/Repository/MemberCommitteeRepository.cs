using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class MemberCommitteeRepository : IMemberCommitteeRepository
    {
        private ApplicationDbContext _context;
        public MemberCommitteeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(MemberCommittee memberCommittee)
        {
            _context.Add(memberCommittee);
            return Save();
        }

        public bool Delete(MemberCommittee memberCommittee)
        {
            _context.Remove(memberCommittee);
            return Save();
        }

        public bool Save(MemberCommittee memberCommittee)
        {
            var saved = _context.SaveChanges();
            return saved> 0 ? true : false;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(MemberCommittee memberCommittee)
        {
            _context.Update(memberCommittee);
            return Save();
        }
    }
}
