using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class CommitteeRepository : ICommitteeRepository
    {
        private ApplicationDbContext _context;
        public CommitteeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Committee committee)
        {
            _context.Add(committee);
            return Save();
        }

        public bool Delete(Committee committee)
        {
            _context.Remove(committee);
            return Save();
        }

        public bool Save()
        {
            var saved= _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Committee committee)
        {
            _context.Update(committee); 
            return Save();
        }
    }
}
