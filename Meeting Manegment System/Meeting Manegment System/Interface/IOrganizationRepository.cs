using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IOrganizationRepository
    {
        bool Add(Organization organization);
        bool Delete(Organization organization);
        bool Update(Organization organization);
        bool Save();
    }
}
