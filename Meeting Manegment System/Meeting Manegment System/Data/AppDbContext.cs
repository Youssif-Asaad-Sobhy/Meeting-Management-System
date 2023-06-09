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
            modelBuilder.Entity<MemberCommittee>().HasKey(am => new
            {
                am.MemberId,
                am.CommitteeId
            });
            modelBuilder.Entity<Voting>().HasKey(am => new
            {
                am.VotingId,
                am.MeetingId
            });


            modelBuilder.Entity<Committee>()
                .HasOne(m=>m.Organization)
                .WithMany(m=>m.Committees)
                .HasForeignKey(m => m.OrganizationId)
                .HasPrincipalKey(m => m.OrganizationId )
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Committee)
                .WithMany(m => m.Meetings)
                .HasForeignKey(m => m.CommitteeId )
                .HasPrincipalKey(m => m.CommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MemberAnswers>()
                .HasOne(m => m.Meeting)
                .WithMany(m => m.MemberAnswers)
                .HasForeignKey(m =>m.MeetingId )
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<MemberAnswers>()
                .HasOne(m => m.Member)
                .WithMany(m => m.MemberAnswers)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MemberAnswers>()
                .HasOne(m => m.Voting)
                .WithMany(m => m.MemberAnswers)
                .HasForeignKey(m => new { m.VotingId ,m.MeetingId})
                .HasPrincipalKey(m => new { m.VotingId, m.MeetingId })
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MemberCommittee>()
                .HasOne(m => m.Member)
                .WithMany(m => m.MemberCommittees)
                .HasForeignKey(m => m.MemberId);

            modelBuilder.Entity<MemberMeeting>()
                .HasOne(m => m.Member)
                .WithMany(m => m.memberMeetings)
                .HasForeignKey(m => m.MemberId)
                .HasPrincipalKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MemberMeeting>()
                .HasOne(m => m.Meeting)
                .WithMany(m => m.memberMeetings)
                .HasForeignKey(m => m.MeetingId)
                .HasPrincipalKey(m => m.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<MemberCommittee>()
                .HasOne(m => m.Committee)
                .WithMany(m => m.MemberCommittees)
                .HasForeignKey(m => m.CommitteeId)
                .HasPrincipalKey(m => m.CommitteeId);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.WordDocument)
                .WithOne(w => w.Meeting)
                .HasForeignKey<WordDocument>(w => w.MeetingId);
            base.OnModelCreating(modelBuilder);

        }

        internal void Delete(Organization organization)
        {
            throw new NotImplementedException();
        }

        public DbSet<Committee> Committee { get; set; }
        public DbSet<MemberMeeting> MemberMeeting { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MemberAnswers> MembersAnswers { get; set; }
        public DbSet<MemberCommittee> MemberCommittees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Voting> Votings { get; set; }
        public DbSet<WordDocument> WordDocuments { get; set; }
    }
}
