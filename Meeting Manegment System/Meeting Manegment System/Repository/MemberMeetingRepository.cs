using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Manegment_System.Repository
{
    public class MemberMeetingRepository : IMemberMeetingRepository
    {
        private ApplicationDbContext _context;
        public MemberMeetingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<MemberMeeting> GetMemberMeetingsByMemberId(int memberId)
        {
            List<MemberMeeting> Models = new();
            Models = _context.MemberMeeting.Include(x=>x.Meeting).Where(x=>x.MemberId== memberId && x.Meeting.Date>=DateTime.Now).ToList();
            return Models;
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
