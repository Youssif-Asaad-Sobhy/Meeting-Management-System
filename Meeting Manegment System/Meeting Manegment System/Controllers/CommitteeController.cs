using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class CommitteeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
