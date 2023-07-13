using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Manegment_System.Repository
{
    public class MemberAnswerRepository : IMemberAnswerRepository
    {
        private ApplicationDbContext _context;
        public MemberAnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteAllMemberAnswersOfVote(int voteId)
        {
            var item=_context.MembersAnswers.FirstOrDefault(x=>x.VotingId==voteId);
            while(item !=null)
            {
                Delete(item);
                item=_context.MembersAnswers.FirstOrDefault(x=>x.VotingId==voteId);
            }

        }
        public List<MemberAnswers> GetByVoteMeetId(int voteid, int meetid)
        {
            return _context.MembersAnswers.Include(x => x.Member).Where(x => x.VotingId == voteid && x.MeetingId == meetid).ToList();
        }
        public MemberAnswers GetByAllId(int MemberId, int MeetingId, int VotingId)
        {
            return _context.MembersAnswers.FirstOrDefault(x => x.MeetingId == MeetingId && x.MemberId == MemberId && x.VotingId == VotingId);
        }

        public bool Add(MemberAnswers memberAnswers)
        {
            _context.Add(memberAnswers);
            return Save();
        }

        public bool Delete(MemberAnswers memberAnswers)
        {
            _context.Remove(memberAnswers);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        public bool Update(MemberAnswers memberAnswers)
        {
            _context.Update(memberAnswers);
            return Save();
        }
    }
}
