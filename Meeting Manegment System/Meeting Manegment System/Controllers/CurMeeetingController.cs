using Meeting_Manegment_System.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class CurMeeetingController : Controller
    {
        private IVotingRepository _voting;
        public CurMeeetingController(IVotingRepository votingRepository)
        {
            _voting = votingRepository;
        }
        public IActionResult Index(int id)
        {
            return View(_voting.GetAllVotingsByMeetingId(id));
        }

    }
}
