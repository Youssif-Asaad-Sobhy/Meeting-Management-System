using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    
    public class CommitteeController : Controller
    {
        private ICommitteeRepository _committee;

        public CommitteeController(ICommitteeRepository committeeRepository) 
        {
            _committee = committeeRepository;
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") != RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") == RoleType.Member)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Committee committee)
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") == RoleType.Member)
            {
                return RedirectToAction("Login", "Home");
            }
            _committee.Add(committee);
            return RedirectToAction("Index","Home");
        }
    }
}
