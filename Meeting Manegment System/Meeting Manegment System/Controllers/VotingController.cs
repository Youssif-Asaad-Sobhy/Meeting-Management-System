using Microsoft.AspNetCore.Mvc;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Meeting_Manegment_System.Controllers
{

    public class VotingController : Controller
    {
        private IVotingRepository _voting;
        private IMemberAnswerRepository _memberAnswer;
        public VotingController(IVotingRepository votingRepository,IMemberAnswerRepository memberAnswer)
        {
            _voting = votingRepository;
            _memberAnswer = memberAnswer;
        }
        public IActionResult Index(int voteid,int meetid)
        {
            List<MemberAnswers>memberAnswers = _memberAnswer.GetByVoteMeetId(voteid,meetid);
            if(memberAnswers.Count == 0)
            {
                var item=new MemberAnswers() { 
                    MeetingId=meetid,
                    Member = new() { Name="لا يوجد ردود بعد"},
                    Response=Reply.NotAnswered
                };
                memberAnswers.Add(item);
            }
            return View(memberAnswers);
        }
        public IActionResult Create(int MeetingId)
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") == RoleType.Member)
            {
                return RedirectToAction("Login", "Home");
            }
            Voting model = new();
            model.MeetingId = MeetingId;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Voting voting)
        {
            if (HttpContext.Session.GetInt32("Role") == null || (RoleType)HttpContext.Session.GetInt32("Role") == RoleType.Member)
            {
                return RedirectToAction("Login", "Home");
            }
            voting.VotingId = _voting.GetMaxId()+1;
            _voting.Add(voting);
            return RedirectToAction("Index", "CurMeeting", new {MeetingId=voting.MeetingId});
        }
    }
}
