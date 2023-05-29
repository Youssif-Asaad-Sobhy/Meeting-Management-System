﻿using Meeting_Manegment_System.Models;
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
            modelBuilder.Entity<MemberAnswers>()
                .HasOne(m => m.Meeting)
                .WithMany(m => m.MemberAnswers)
                .HasForeignKey(m => m.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemberAnswers>()
                .HasOne(m => m.Member)
                .WithMany(m => m.MemberAnswers)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MemberAnswers>()
                .HasOne(m => m.Voting)
                .WithMany(m => m.MemberAnswers)
                .HasForeignKey(m => m.VotingId)
                .OnDelete(DeleteBehavior.Restrict);


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


        public DbSet<Committee> Committee { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MemberAnswers> MembersAnswers { get; set; }
        public DbSet<MemberCommittee> MemberCommittees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Voting> Votings { get; set; }
    }
}
