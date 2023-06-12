using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Meeting_Manegment_System.Controllers
{
    public class MainController : Controller
    {
        private IMemberCommitteeRepository _memberCommittee;
        private IMemberRepository _member;

        public MainController(IMemberCommitteeRepository memberCommitteeRepository, IMemberRepository memberRepository)
        {
            _memberCommittee = memberCommitteeRepository;
            _member = memberRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SelectCommittee(int id)
        {
            SelectCommitteeView model = new SelectCommitteeView();
            var member = _member.GetMemberById(id);
            model.member = member;
            model.commits = _memberCommittee.GetCommitteesByMemberId(id);
            return View(model);
        }
        public IActionResult CommitteeMembers(int MemberId,int CommitteeId)
        {
            CommitteeMembersView model=new CommitteeMembersView();
            model.members = _memberCommittee.GetMembersInCommittee(CommitteeId);
            model.Member.MemberId = MemberId;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectCommittee(SelectCommitteeView model)
        {
            return RedirectToAction("CommitteeMembers", new { MemberId = model.member.MemberId, CommitteeId = model.SelectedId });
        }
    }
}
