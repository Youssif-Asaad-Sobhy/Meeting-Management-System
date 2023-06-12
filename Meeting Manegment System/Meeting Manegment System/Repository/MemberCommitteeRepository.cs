using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Manegment_System.Repository
{
    public class MemberCommitteeRepository : IMemberCommitteeRepository
    {
        private ApplicationDbContext _context;
        public MemberCommitteeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<MemberCommittee> GetMembersInCommittee(int CommitteeId)
        {
            return _context.MemberCommittees.Include(x=>x.Member).Where(x=>x.CommitteeId==CommitteeId).ToList();
        }
        public List<Committee> GetCommitteesByMemberId(int memberId)
        {
            var committeeIds = _context.MemberCommittees
            .Where(mc => mc.MemberId == memberId)
            .Select(mc => mc.CommitteeId)
            .ToList();
            var committees = _context.Committee
                .Where(c => committeeIds.Contains(c.CommitteeId))
                .ToList();
            return committees;
        }

        public bool Add(MemberCommittee memberCommittee)
        {
            _context.Add(memberCommittee);
            return Save();
        }

        public bool Delete(MemberCommittee memberCommittee)
        {
            _context.Remove(memberCommittee);
            return Save();
        }
        public bool Update(MemberCommittee memberCommittee)
        {
            _context.Update(memberCommittee);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved> 0 ? true : false;
        }

    }
}
