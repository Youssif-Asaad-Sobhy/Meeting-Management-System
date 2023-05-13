using Meeting_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;
using Meeting_Manegment_System.Models;
namespace Meeting_Manegment_System.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberAnswers>().HasKey(am => new
            {
                am.VotingId,
                am.MeetingId,
                am.MemberId
            });
            modelBuilder.Entity<MemberAnswers>().HasOne(m => m.Voting).WithMany(m => m.MemberAnswers
            ).HasForeignKey(m => m.VotingId);
            modelBuilder.Entity<MemberAnswers>().HasOne(m => m.Meeting).WithMany(m => m.MemberAnswers
            ).HasForeignKey(m => m.MeetingId);
            modelBuilder.Entity<MemberAnswers>().HasOne(m => m.Member).WithMany(m => m.MemberAnswers
            ).HasForeignKey(m => m.MemberId);

            modelBuilder.Entity<MemberCommittee>().HasKey(am => new
            {
                am.MemberId,
                am.CommitteeId
            });
            modelBuilder.Entity<MemberCommittee>().HasOne(m => m.Member).WithMany(m => m.MemberCommittees
            ).HasForeignKey(m => m.MemberId);
            modelBuilder.Entity<MemberCommittee>().HasOne(m => m.Committee).WithMany(m => m.MemberCommittees
            ).HasForeignKey(m => m.CommitteeId);

            base.OnModelCreating(modelBuilder);
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
