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

        public UserPageController(IMemberRepository memberRepository)
        {
            _member = memberRepository;
        }
        public IActionResult Index(int id)
        {
            Member member =_member.GetMemberById(id);
            return View(member);
        }
        [HttpPost]
        public IActionResult ForgetPassword(int id , string curpassword, string newpassword)
        {
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
