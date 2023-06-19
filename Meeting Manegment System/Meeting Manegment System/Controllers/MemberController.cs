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
        public IActionResult Create(int error=0) 
        {
            if(HttpContext.Session.GetInt32("Role") == null|| (RoleType)HttpContext.Session.GetInt32("Role")!=RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            if(error!=0)
                ViewBag.Error = "هذا الايميل موجود بالفعل";
            Member model = new Member();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") != RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(_member.GetMemberById(id));
        }
        public IActionResult Delete(int id)
        {
            Member member = _member.GetMemberById(id);
            _member.Delete(member);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if(_member.GetMemberByEmail(member.Email) != null)
            {
                return RedirectToAction("Create", new {error=1});
            }
            _member.Add(member);
            return RedirectToAction("HomeController","Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Member member)
        {
            _member.Update(member);
            return RedirectToAction("Index");
        }
    }
}
