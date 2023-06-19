using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private ApplicationDbContext _context;
        public MeetingRepository(ApplicationDbContext context)
        {
            _context=context;
        }
       public List<Meeting> GetMeetingByCommitteeId(int id)
        {
            return _context.Meeting.Where(x => x.CommitteeId == id&&x.EndDate<=DateTime.Now).ToList();
        }
        public Meeting GetMeetingById(int id)
        {
            return _context.Meeting.Where(x => x.MeetingId == id).FirstOrDefault();
        }
        public bool Add(Meeting meeting)
        {
            _context.Add(meeting);
            return Save();
        }

        public bool Delete(Meeting meeting)
        {
            _context.Remove(meeting);
            return Save();
        }

        public bool Save()
        {
            var saved= _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Meeting meeting)
        {
            _context.Update(meeting);
            return Save();
        }
    }
}
