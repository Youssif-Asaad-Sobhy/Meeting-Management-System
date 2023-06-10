using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class ReportRepository : IReportRepository
    {
        private ApplicationDbContext _context;
        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Report report)
        {
            _context.Add(report);
            return Save(); 
        }

        public bool Delete(Report report)
        {
            _context.Remove(report);
            return Save();
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Report report)
        {
            _context.Update(report);
            return Save();
        }
    }
}
