using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _meeting;
        public MeetingController(IMeetingRepository meeting)
        {
             _meeting = meeting;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") == RoleType.Member)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(new Meeting());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Meeting meeting)
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") == RoleType.Member)
            {
                return RedirectToAction("Login", "Home");
            }
            meeting.CommitteeId =(int) HttpContext.Session.GetInt32("CommitteeId");
            meeting.DocumentId = 0;
            _meeting.Add(meeting);
            return RedirectToAction("Index","UpcommingMeeting");
        }
    }
}
