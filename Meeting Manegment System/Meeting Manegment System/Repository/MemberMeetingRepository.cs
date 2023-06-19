using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace Meeting_Manegment_System.Repository
{
    public class MemberMeetingRepository : IMemberMeetingRepository
    {
        private ApplicationDbContext _context;
        private IHttpContextAccessor _session;

        public MemberMeetingRepository(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor;
        }
        public MemberMeeting GetMemberMeetingById(int Id)
        {
            return _context.MemberMeeting.FirstOrDefault(x => x.MemberMeetingId == Id);
        }
        public List<MemberMeeting> GetMemberMeetingsByCommitteeId(int CommitteeId)
        {
            List<Meeting> Models = new();
            Models = _context.Meeting.Where(x =>x.EndDate >= DateTime.Now && x.CommitteeId == CommitteeId).ToList();
            List<MemberMeeting> ret = new();
            int memberid = (int)_session.HttpContext.Session.GetInt32("MemberId");
            foreach (Meeting meeting in Models)
            {
                MemberMeeting membermeeting = _context.MemberMeeting.FirstOrDefault(x => x.MemberId == memberid && x.MeetingId == meeting.MeetingId);
                if(membermeeting != null)
                {
                    ret.Add(membermeeting);
                }
                else
                {
                    membermeeting = new MemberMeeting
                    {
                         MemberId=memberid,
                         MeetingId=meeting.MeetingId,
                         Response=State.NotAnswerd
                    };
                    Add(membermeeting);
                    ret.Add(membermeeting);
                }
            }
            return ret;
        }
        public bool Add(MemberMeeting memberMeeting)
        {
            _context.Add(memberMeeting);
            return Save();
        }

        public bool Delete(MemberMeeting memberMeeting)
        {
            _context.Remove(memberMeeting);
            return Save();
        }
        public bool Update(MemberMeeting memberMeeting)
        {
            _context.Update(memberMeeting);
            return Save();
        }
        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved>0?true:false;
        }
    }
}
