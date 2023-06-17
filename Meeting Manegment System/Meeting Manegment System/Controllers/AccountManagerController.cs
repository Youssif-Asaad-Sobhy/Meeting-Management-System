using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class AccountManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private IMemberRepository _member;
        public AccountManagerController(IMemberRepository memberRepository,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _userManager = userManager; 
            _signInManager = signInManager;
            _member = memberRepository;
        }
        public IActionResult Login()
        {
            return View(new Member());
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Login(Member model)
        {
            if (!ModelState.IsValid) { return View(model); }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null) {
                var passCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if(passCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if(result.Succeeded)
                    {
                        HttpContext.Session.SetInt32("MemberId",_member.GetMemberByEmail(model.Email).MemberId);
                        return RedirectToAction("SelectCommittee","Main");
                    }
                }
            }
            TempData["Error"] = "اسم المستخدم او كلمة المرور غير صحيحه";
            return View(model);
        }*/

    }
}
