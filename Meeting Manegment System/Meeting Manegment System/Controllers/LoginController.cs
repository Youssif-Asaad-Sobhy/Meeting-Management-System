using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Mvc;
using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Controllers;

namespace Meeting_Manegment_System.Controllers
{
    public class LoginController : Controller
    {
        public struct Cname
        {
            public int id { get; set; }
            public string Name { get; set; }
        }
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CommitteeSelect()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Member model)
        {
            if (ModelState.IsValid)
            {
                // Check if username and password match in the database
                bool isValidUser = _context.Member.Any(u => u.Email == model.Email && u.Password == model.Password);
                if (isValidUser)
                {
                    List<MemberCommittee> commits = new List<MemberCommittee>();
                    commits =  _context.MemberCommittees.Where(x=>x.MemberId==model.MemberId).ToList();
                    List<Cname> cnames = new List<Cname>(); 
                    Cname temp=new Cname();
                    foreach (var comm in commits)
                    {
                        var name=_context.Committee.Where(x => x.CommitteeId == comm.CommitteeId).FirstOrDefault();
                        temp.Name = name.Name;
                        temp.id = name.CommitteeId;
                        cnames.Add(temp);
                    }
                    ViewBag.Committees = cnames;
                    return RedirectToAction("CommitteeSelect", "Login",model);
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
        [HttpPost]
        public IActionResult CommitteeSelect(MemberCommittee model)
        {
            string role = model.Role.ToString();
            if (role == "President")
            {
                return RedirectToAction("Index", "PresidentController");
            }
            else if (role == "Vice")
            {
                return RedirectToAction("Index", "ViceController");
            }
            else return RedirectToAction("Index", "UserConroller");
            return View();
        }
    }
}
