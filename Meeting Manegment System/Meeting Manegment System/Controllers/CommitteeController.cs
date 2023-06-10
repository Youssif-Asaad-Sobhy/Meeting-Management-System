using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            Committee model = new Committee();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Committee committee)
        {
            _committee.Add(committee);
            return RedirectToAction("Index","Home");
        }
    }
}
