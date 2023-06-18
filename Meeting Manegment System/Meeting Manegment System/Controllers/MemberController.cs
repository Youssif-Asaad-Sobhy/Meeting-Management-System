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
            return View();
        }
        public IActionResult Create() 
        {
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
