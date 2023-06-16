using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Meeting_Manegment_System.Controllers
{
    public class MainController : Controller
    {
        private IMemberCommitteeRepository _memberCommittee;
        private IMemberRepository _member;
        private IHttpContextAccessor _session;
        public MainController(IHttpContextAccessor session,IMemberCommitteeRepository memberCommitteeRepository, IMemberRepository memberRepository)
        {
            _memberCommittee = memberCommitteeRepository;
            _member = memberRepository;
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SelectCommittee()
        {
            int id =(int) _session.HttpContext.Session.GetInt32("MemberId");
            SelectCommitteeView model = new ();
            var member = _member.GetMemberById(id);
            model.member = member;
            model.commits = _memberCommittee.GetCommitteesByMemberId(id);
            return View(model);
        }
        public IActionResult CommitteeMembers()
        {
            int MemberId = (int)_session.HttpContext.Session.GetInt32("MemberId");
            int CommitteeId = (int)_session.HttpContext.Session.GetInt32("CommitteeId");
            CommitteeMembersView model =new();
            model.members = _memberCommittee.GetMembersInCommittee(CommitteeId);
            model.Member.MemberId = MemberId;
            return View(model);
        }
        public IActionResult Logout()
        {
            _session.HttpContext.Session.Clear();
            return RedirectToAction("Login","Home");
        }
        [HttpPost]
        public IActionResult SelectCommittee(SelectCommitteeView model)
        {
            _session.HttpContext.Session.SetInt32("CommitteeId",model.SelectedId);
            return RedirectToAction("CommitteeMembers");
        }
    }
}
