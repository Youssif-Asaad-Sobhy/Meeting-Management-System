using Meeting_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Manegment_System.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {  
        }

       

        public DbSet<Committee> Committees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberAnswers> MembersAnswers { get; set; }
        public DbSet<MemberCommittee> MemberCommittees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Voting> Votings { get; set; }
    }
}
