using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Delete(Member member)
        {
            RoleType role =(RoleType) HttpContext.Session.GetInt32("Role");
            if (role==null&&role!=RoleType.Admin)
            {
                return RedirectToAction("Login", "Home");
            }
            return RedirectToAction("Index", "Member");
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("MemberId") == null )
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public IActionResult SelectCommittee()
        {
            if (HttpContext.Session.GetInt32("MemberId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int id =(int) HttpContext.Session.GetInt32("MemberId");
            SelectCommitteeView model = new ();
            var member = _member.GetMemberById(id);
            model.member = member;
            model.commits = _memberCommittee.GetCommitteesByMemberId(id);
            return View(model);
        }
        public IActionResult CommitteeMembers()
        {
            if (HttpContext.Session.GetInt32("MemberId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int MemberId = (int)HttpContext.Session.GetInt32("MemberId");
            int CommitteeId = (int)HttpContext.Session.GetInt32("CommitteeId");
            HttpContext.Session.SetInt32("Role",(int) _memberCommittee.GetRoleTypeById(MemberId, CommitteeId));
            CommitteeMembersView model =new();
            model.members = _memberCommittee.GetMembersInCommittee(CommitteeId);
            model.Member.MemberId = MemberId;
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public IActionResult SelectCommittee(SelectCommitteeView model)
        {
            if (HttpContext.Session.GetInt32("MemberId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpContext.Session.SetInt32("CommitteeId",model.SelectedId);
            return RedirectToAction("CommitteeMembers");
        }
    }
}
