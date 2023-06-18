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

        public UserPageController(IHttpContextAccessor session,IMemberRepository memberRepository)
        {
            _member = memberRepository;
        }
        public IActionResult Index()
        {
            int id=(int)HttpContext.Session.GetInt32("MemberId");
            ProfilePageView Model = new();
            Model.Member =_member.GetMemberById(id);
            Model.Role =(RoleType) HttpContext.Session.GetInt32("Role");
            return View(Model);
        }
        public IActionResult ForgetPassword()
        {
            return View(new Member());
        }
        public IActionResult Delete()
        {
            return RedirectToAction("Index", "Member");
        }
        public IActionResult NewMember()
        {
            return RedirectToAction("Create","Member");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgetPassword(string curpassword, string newpassword)
        {
            int id = (int)HttpContext.Session.GetInt32("MemberId");
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
