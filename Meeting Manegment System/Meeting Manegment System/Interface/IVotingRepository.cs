using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IVotingRepository
    {
        bool Add(Voting voting); 
        bool Delete(Voting voting);
        bool Update(Voting voting);
        bool Save();
    }
}
