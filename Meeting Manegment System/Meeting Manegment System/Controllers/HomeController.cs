using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Meeting_Manegment_System.Controllers
{
    public class HomeController : Controller
    {
        private IMemberRepository _member;

        public HomeController(IMemberRepository memberRepository) 
        {
            _member = memberRepository;
        }
        public IActionResult Index()
        {
            ViewBag.IsGood = true;
            return View();
        }
        public IActionResult Login()
        {
            return View("Index");
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            ViewBag.Email = 0;
            return View(new ForgetPasswordView());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Member member)
        {
            member = _member.IsMember(member);
            if (member!=null)
            {
                return RedirectToAction("SelectCommittee","Main",new { id = member.MemberId });
            }
            ViewBag.IsGood = false;
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgetPassword(ForgetPasswordView model) 
        {
            if(_member.GetMemberByEmail(model.Email)!=null)
                ViewBag.Email = 1;
            else ViewBag.Email = 2;
            return View();
        }
    }
}