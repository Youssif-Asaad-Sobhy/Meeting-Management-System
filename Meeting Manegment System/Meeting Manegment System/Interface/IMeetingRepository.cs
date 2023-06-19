using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMeetingRepository
    {
        List<Meeting> GetMeetingByCommitteeId(int id);
        Meeting GetMeetingById(int id);
        bool Add(Meeting meeting); 
        bool Delete (Meeting meeting);
        bool Update (Meeting meeting);
        bool Save();
    }
}
