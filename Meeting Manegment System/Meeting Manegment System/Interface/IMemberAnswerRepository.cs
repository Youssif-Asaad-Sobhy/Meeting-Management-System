using Meeting_Manegment_System.Models;
using System;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberAnswerRepository
    {
        void DeleteAllMemberAnswersOfVote(int voteId);
        List<MemberAnswers> GetByVoteMeetId(int voteid, int meetid);
        MemberAnswers GetByAllId(int MemberId, int MeetingId, int VotingId);
        bool Save();
        bool Delete(MemberAnswers memberAnswers);
        bool Update(MemberAnswers memberAnswers);
        bool Add (MemberAnswers memberAnswers);
    }
}
