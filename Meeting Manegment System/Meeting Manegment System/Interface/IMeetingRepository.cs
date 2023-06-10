using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMeetingRepository
    {
        bool Add(Meeting meeting); 
        bool Delete (Meeting meeting);
        bool Update (Meeting meeting);
        bool Save();
    }
}
