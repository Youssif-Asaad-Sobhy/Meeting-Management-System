using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class PreviousMeetingController : Controller
    {
        private IMemberRepository _member;
        private IMeetingRepository _meeting;

        public PreviousMeetingController(IMemberRepository memberRepository, IMeetingRepository meetingRepository)
        {
            _member = memberRepository;
            _meeting = meetingRepository;
        }
        public IActionResult Index(int CommitteeId, int MemberId)
        {
            PreviousMeetingView PMV = new PreviousMeetingView();
             PMV.meetings = _meeting.GetMeetingByCommitteeId(CommitteeId);
            PMV.MemberId = MemberId; 
            return View(PMV);
        }
        
    }
}
