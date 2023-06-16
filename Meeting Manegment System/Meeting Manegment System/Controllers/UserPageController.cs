using Microsoft.AspNetCore.Mvc;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.ViewModels;
using Meeting_Manegment_System.Repository;

namespace Meeting_Manegment_System.Controllers
{
    public class UserPageController : Controller
    {
        private  IMemberRepository _member;
        private IHttpContextAccessor _session;

        public UserPageController(IHttpContextAccessor session,IMemberRepository memberRepository)
        {
            _member = memberRepository;
            _session = session;
        }
        public IActionResult Index()
        {
            int id=(int)HttpContext.Session.GetInt32("MemberId");
            Member member =_member.GetMemberById(id);
            return View(member);
        }
        public IActionResult ForgetPassword()
        {
            return View(new Member());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgetPassword(string curpassword, string newpassword)
        {
            int id = (int)_session.HttpContext.Session.GetInt32("MemberId");
            Member member = _member.GetMemberById(id); 
            if (member.Password == curpassword)
            {
                member.Password = newpassword;
                _member.Update(member);
                ViewBag.Message = "Password changed successfully.";
            }
            else
            {
                ViewBag.Error = "Invalid current password.";
            }
            return View();
        }
    }
}
