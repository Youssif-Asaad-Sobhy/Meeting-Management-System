using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepository _member;

        public MemberController(IMemberRepository memberRepository) 
        { 
            _member = memberRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") != RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Member> model =_member.GetMembersExeptId((int)HttpContext.Session.GetInt32("MemberId"));
            return View(model);
        }
        public IActionResult Create() 
        {
            if(HttpContext.Session.GetInt32("Role") == null|| (RoleType)HttpContext.Session.GetInt32("Role")!=RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            Member model = new Member();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            _member.Add(member);
            return RedirectToAction("HomeController","Index");
        }
    }
}
