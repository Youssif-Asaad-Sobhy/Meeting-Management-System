using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
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
            MemberCommittee model = new MemberCommittee();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberCommittee membercommittee)
        {
            _memberCommittee.Add(membercommittee);
            return RedirectToAction("Index", "Home");
        }
    }
}
