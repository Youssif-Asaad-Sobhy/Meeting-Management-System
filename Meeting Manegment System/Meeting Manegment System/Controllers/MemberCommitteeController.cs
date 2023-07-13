using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{

    public class MemberCommitteeController : Controller
    {
        private IMemberCommitteeRepository _memberCommittee;

        public MemberCommitteeController(IMemberCommitteeRepository membercommitteeRepository) 
        { 
            _memberCommittee = membercommitteeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") != RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            MemberCommittee model = new MemberCommittee();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberCommittee membercommittee)
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") != RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            _memberCommittee.Add(membercommittee);
            return RedirectToAction("Index", "Home");
        }
    }
}
