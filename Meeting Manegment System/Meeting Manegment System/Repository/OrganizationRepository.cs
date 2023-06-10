using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class OrganizationRctorepository: IOrganizationRepository
    {
        private ApplicationDbContext _context;
        public OrganizationRctorepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Organization organization)
        {
            _context.Add(organization);
            return Save();
        }

        public bool Delete(Organization organization)
        {
            _context.Remove(organization);
            return Save();
        }

        public bool Save()
        {
            var saved =_context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Organization organization)
        {
            _context.Update(organization);
            return Save();
        }
    }
}
