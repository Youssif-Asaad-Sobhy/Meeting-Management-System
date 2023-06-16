using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IMemberMeetingRepository
    {
        List<MemberMeeting> GetMemberMeetingsByMemberId(int memberId);
        MemberMeeting GetMemberMeetingById(int Id);
        bool Add(MemberMeeting memberMeeting);
        bool Delete(MemberMeeting memberMeeting);
        bool Update(MemberMeeting memberMeeting);
        bool Save();
    }
}
