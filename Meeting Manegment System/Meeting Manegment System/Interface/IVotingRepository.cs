using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IVotingRepository
    {
        int GetMaxId();
        Voting GetById(int id);
        List<Voting> GetAllVotingsByMeetingId(int id);
        bool Add(Voting voting); 
        bool Delete(Voting voting);
        bool Update(Voting voting);
        bool Save();
    }
}
