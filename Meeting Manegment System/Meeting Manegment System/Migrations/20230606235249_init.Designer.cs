﻿// <auto-generated />
using System;
using Meeting_Manegment_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meeting_Manegment_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230606235249_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Meeting_Manegment_System.Models.Committee", b =>
                {
                    b.Property<int>("CommitteeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommitteeId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("CommitteeId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Committee");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Meeting", b =>
                {
                    b.Property<int>("MeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetingId"));

                    b.Property<int>("CommitteeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Emergency")
                        .HasColumnType("bit");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingId");

                    b.HasIndex("CommitteeId");

                    b.ToTable("Meeting");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.MemberAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommitteeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeetingId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("VotingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("MemberId");

                    b.HasIndex("VotingId", "MeetingId");

                    b.ToTable("MembersAnswers");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.MemberCommittee", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("CommitteeId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "CommitteeId");

                    b.HasIndex("CommitteeId");

                    b.ToTable("MemberCommittees");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeetingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Voting", b =>
                {
                    b.Property<int>("VotingId")
                        .HasColumnType("int");

                    b.Property<int>("MeetingId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VotingId", "MeetingId");

                    b.HasIndex("MeetingId");

                    b.ToTable("Votings");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Committee", b =>
                {
                    b.HasOne("Meeting_Manegment_System.Models.Organization", "Organization")
                        .WithMany("Committees")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Meeting", b =>
                {
                    b.HasOne("Meeting_Manegment_System.Models.Committee", "Committee")
                        .WithMany("Meetings")
                        .HasForeignKey("CommitteeId")
                        .IsRequired();

                    b.Navigation("Committee");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.MemberAnswers", b =>
                {
                    b.HasOne("Meeting_Manegment_System.Models.Meeting", "Meeting")
                        .WithMany("MemberAnswers")
                        .HasForeignKey("MeetingId")
                        .IsRequired();

                    b.HasOne("Meeting_Manegment_System.Models.Member", "Member")
                        .WithMany("MemberAnswers")
                        .HasForeignKey("MemberId")
                        .IsRequired();

                    b.HasOne("Meeting_Manegment_System.Models.Voting", "Voting")
                        .WithMany("MemberAnswers")
                        .HasForeignKey("VotingId", "MeetingId")
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("Member");

                    b.Navigation("Voting");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.MemberCommittee", b =>
                {
                    b.HasOne("Meeting_Manegment_System.Models.Committee", "Committee")
                        .WithMany("MemberCommittees")
                        .HasForeignKey("CommitteeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meeting_Manegment_System.Models.Member", "Member")
                        .WithMany("MemberCommittees")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Committee");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Report", b =>
                {
                    b.HasOne("Meeting_Manegment_System.Models.Meeting", "Meeting")
                        .WithMany("Reports")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Voting", b =>
                {
                    b.HasOne("Meeting_Manegment_System.Models.Meeting", "Meeting")
                        .WithMany("Votings")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Committee", b =>
                {
                    b.Navigation("Meetings");

                    b.Navigation("MemberCommittees");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Meeting", b =>
                {
                    b.Navigation("MemberAnswers");

                    b.Navigation("Reports");

                    b.Navigation("Votings");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Member", b =>
                {
                    b.Navigation("MemberAnswers");

                    b.Navigation("MemberCommittees");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Organization", b =>
                {
                    b.Navigation("Committees");
                });

            modelBuilder.Entity("Meeting_Manegment_System.Models.Voting", b =>
                {
                    b.Navigation("MemberAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}