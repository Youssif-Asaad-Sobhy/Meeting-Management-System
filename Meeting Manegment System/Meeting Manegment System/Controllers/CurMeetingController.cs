using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    
    public class CurMeetingController : Controller
    {
        private IVotingRepository _voting;
        private IMemberAnswerRepository _memberAnswers;
        public CurMeetingController(IMemberAnswerRepository memberAnswerRepository ,IVotingRepository votingRepository)
        {
            _voting = votingRepository;
            _memberAnswers = memberAnswerRepository;
        }
        public IActionResult Index(int MeetingId)
        {
            if (HttpContext.Session.GetInt32("Role") == null )
            {
                return RedirectToAction("Login", "Home");
            }
            int MemberId = (int)HttpContext.Session.GetInt32("MemberId");
            List<Voting> Vote = _voting.GetAllVotingsByMeetingId(MeetingId);
            List<MemberAnswers>memberAnswers = new List<MemberAnswers>();
            for(int i = 0;i< Vote.Count;i++)
            {
                var item=_memberAnswers.GetByAllId(MemberId, Vote[i].MeetingId, Vote[i].VotingId);
                if (item == null)
                {
                    memberAnswers.Add(new MemberAnswers { Response= Reply.NotAnswered});
                }
                else memberAnswers.Add(item);
            }
            return View(new VotingView { Votings=Vote,MemberAnswers=memberAnswers,Role=(RoleType)HttpContext.Session.GetInt32("Role"),MeetingId=MeetingId});
        }
        public IActionResult Delete(int voteid,int meetid)
        {
            _memberAnswers.DeleteAllMemberAnswersOfVote(voteid);
            var item = _voting.GetById(voteid);
            _voting.Delete(item);
            return RedirectToAction("Index", new { MeetingId = meetid });
        }
        public IActionResult ShowVote(int voteid,int meetid)
        {
            if (HttpContext.Session.GetInt32("Role") == null || HttpContext.Session.GetInt32("Role")==(int)RoleType.Member)
            {
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("Index", "Voting", new {voteid=voteid,meetid=meetid});
        }
        [HttpPost]
        public IActionResult Vote(string comment,int VoteId,int vote,int MeetId)
        {
            if(vote==3)
            {
                return RedirectToAction("Index", new {MeetingId=MeetId});
            }
            int MemberId = (int)HttpContext.Session.GetInt32("MemberId");
            MemberAnswers item = new() { 
                Comment=comment,
                MeetingId=MeetId,
                MemberId=MemberId,
                VotingId=VoteId,
                Response=(Reply)vote
            };
            _memberAnswers.Add(item);
            return RedirectToAction("Index", new { MeetingId = MeetId });
        }

    }
}
