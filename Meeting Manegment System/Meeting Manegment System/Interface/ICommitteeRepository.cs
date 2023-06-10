using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface ICommitteeRepository
    {
        bool Add(Committee committee); 
        bool Update(Committee committee);
        bool Delete(Committee committee);
        bool Save();
    }
}
