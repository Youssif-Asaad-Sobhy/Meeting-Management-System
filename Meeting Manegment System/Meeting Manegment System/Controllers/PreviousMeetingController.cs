using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{

    public class PreviousMeetingController : Controller
    {
        private IMemberRepository _member;
        private IMeetingRepository _meeting;
        private IHttpContextAccessor _session;

        public PreviousMeetingController(IHttpContextAccessor httpContextAccessor ,IMemberRepository memberRepository, IMeetingRepository meetingRepository)
        {
            _member = memberRepository;
            _meeting = meetingRepository;
            _session = httpContextAccessor;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Role") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int MemberId = (int)_session.HttpContext.Session.GetInt32("MemberId");
            int CommitteeId = (int)_session.HttpContext.Session.GetInt32("CommitteeId");
            PreviousMeetingView PMV = new PreviousMeetingView();
            PMV.meetings = _meeting.GetMeetingByCommitteeId(CommitteeId);
            PMV.MemberId = MemberId;
            PMV.Role =(RoleType) HttpContext.Session.GetInt32("Role");
            return View(PMV);
        }
        
    }
}
