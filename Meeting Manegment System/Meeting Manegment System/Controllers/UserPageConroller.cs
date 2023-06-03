using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class UserPageConroller : Controller
    {
        public IActionResult Index(MemberCommittee model)
        {
            if (model.Role == "Vice")
                return RedirectToAction("Vice", "UserPageController",model);
            else if (model.Role == "President")
                return RedirectToAction("President", "UserPageController",model);
            else if (model.Role == "Member")
                return RedirectToAction("Index","UserPageController",model);
            return View(model);
        }

    }
}
