using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class UpcommingMeetingController : Controller
    {
        private IHttpContextAccessor _session;
        private IMemberMeetingRepository _memberMeeting;
        public UpcommingMeetingController(IMemberMeetingRepository memberMeetingRepository,IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor;
            _memberMeeting = memberMeetingRepository;
        }
        public IActionResult Index()
        {
            int MemberId = (int)_session.HttpContext.Session.GetInt32("MemberId");
            List<MemberMeeting> model = _memberMeeting.GetMemberMeetingsByMemberId(MemberId);
            return View(model);
        }
    }
}
