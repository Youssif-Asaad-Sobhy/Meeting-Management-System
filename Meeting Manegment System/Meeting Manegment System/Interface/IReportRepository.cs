using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IReportRepository
    {
        bool Add(Report report); 
        bool Update(Report report);
        bool Delete(Report report);
        bool Save();
    }
}
