using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    
    public class UpcommingMeetingController : Controller
    {
        private IHttpContextAccessor _session;
        private IMemberMeetingRepository _memberMeeting;
        private IMeetingRepository _meeting;
        public UpcommingMeetingController(IMeetingRepository meeting,IMemberMeetingRepository memberMeetingRepository,IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor;
            _memberMeeting = memberMeetingRepository;
            _meeting=meeting;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Role") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int CommitteeId = (int)_session.HttpContext.Session.GetInt32("CommitteeId");
            List<MemberMeeting> model = _memberMeeting.GetMemberMeetingsByCommitteeId(CommitteeId);
            model.Sort((m1, m2) => m1.Meeting.StartDate.CompareTo(m2.Meeting.StartDate));
            return View(model);
        }
        public IActionResult AddResponse(int Response,int id)
        {
            if (HttpContext.Session.GetInt32("Role") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            MemberMeeting model = _memberMeeting.GetMemberMeetingById(id);
            model.Response = (State)Response;
            _memberMeeting.Update(model);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("Role") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Meeting model=_meeting.GetMeetingById(id);
            return View(model);
        }
    }
}
