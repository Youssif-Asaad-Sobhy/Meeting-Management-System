using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Organization
                if (!context.Organizations.Any())
                {
                    context.Organizations.AddRange(new List<Organization>()
                    {
                        new Organization { 
                            //OrganizationId = 1,
                            Name = "Organization 1"
                        }
                    });
                    context.SaveChanges();
                }
                //Committee
                if (!context.Committee.Any())
                {
                    context.Committee.AddRange(new List<Committee>()
                    {
                        new Committee {
                            //CommitteeId = 1,
                            OrganizationId = 1,
                            Name = "Committee 1",
                            Description = "Description 1"
                        },
                        new Committee {
                            //CommitteeId = 2,
                            OrganizationId = 1,
                            Name = "Committee 2",
                            Description = "Description 2"
                        },
                        new Committee {
                            CommitteeId = 3,
                            OrganizationId = 1,
                            Name = "Committee 3",
                            Description = "Description 3"
                        },
                        new Committee {
                            //CommitteeId = 4,
                            OrganizationId = 1,
                            Name = "Committee 4",
                            Description = "Description 4"
                        },
                        new Committee {
                            //CommitteeId = 5,
                            OrganizationId = 1,
                            Name = "Committee 5",
                            Description = "Description 5"
                        }
                    });
                    context.SaveChanges();
                }

                //Meeting
                if (!context.Meeting.Any())
                {
                    context.Meeting.AddRange(new List<Meeting>()
                    {
                        new Meeting {
                            //MeetingId = 1,
                            CommitteeId = 5,
                            Goal = "Goal 1",
                            Emergency = false
                        },
                        new Meeting {
                            //MeetingId = 2, 
                            CommitteeId = 5,
                            Goal = "Goal 2",
                            Emergency = true
                        },
                        new Meeting { 
                            //MeetingId = 3, 
                            CommitteeId = 6,
                            Goal = "Goal 3",
                            Emergency = false
                        },
                        new Meeting { 
                            //MeetingId = 4,
                            CommitteeId = 6,
                            Goal = "Goal 4",
                            Emergency = false
                        },
                        new Meeting {
                            //MeetingId = 5,
                            CommitteeId = 7,
                            Goal = "Goal 5",
                            Emergency = true
                        },
                        new Meeting {
                            //MeetingId = 6,
                            CommitteeId = 7,
                            Goal = "Goal 6",
                            Emergency = false
                        },
                        new Meeting {
                            //MeetingId = 7, 
                            CommitteeId = 8,
                            Goal = "Goal 7",
                            Emergency = false
                        },
                        new Meeting { 
                            //MeetingId = 8,
                            CommitteeId = 8,
                            Goal = "Goal 8",
                            Emergency = true
                        },
                        new Meeting {
                            //MeetingId = 9,
                            CommitteeId = 9,
                            Goal = "Goal 9",
                            Emergency = false
                        },
                        new Meeting { 
                            //MeetingId = 10,
                            CommitteeId = 9,
                            Goal = "Goal 10",
                            Emergency = true
                        }

                    });
                    context.SaveChanges();
                }
                //Member
                if (!context.Member.Any())
                {
                    context.Member.AddRange(new List<Member>()
                    {
                        new Member { 
                            //MemberId = 1, 
                            Name = "Member 1",
                            Email = "member1@example.com",
                            Phone = "1234567890",
                            Password = "password1"
                        },
                        new Member { 
                            //MemberId = 2, 
                            Name = "Member 2",
                            Email = "member2@example.com",
                            Phone = "2345678901",
                            Password = "password2"
                        },
                        new Member {
                            //MemberId = 3,
                            Name = "Member 3",
                            Email = "member3@example.com",
                            Phone = "3456789012",
                            Password = "password3"
                        },
                        new Member {
                            //MemberId = 4, 
                            Name = "Member 4",
                            Email = "member4@example.com",
                            Phone = "4567890123",
                            Password = "password4"
                        },
                        new Member {
                           // MemberId = 5,
                            Name = "Member 5",
                            Email = "member5@example.com",
                            Phone = "5678901234",
                            Password = "password5"
                        },
                        new Member {
                           // MemberId = 6, 
                            Name = "Member 6",
                            Email = "member6@example.com",
                            Phone = "6789012345",
                            Password = "password6"
                        },
                        new Member { 
                            //MemberId = 7,
                            Name = "Member 7",
                            Email = "member7@example.com",
                            Phone = "7890123456",
                            Password = "password7"
                        },
                        new Member {
                            //MemberId = 8,
                            Name = "Member 8",
                            Email = "member8@example.com",
                            Phone = "8901234567", Password = "password8"
                        },
                        new Member {
                           // MemberId = 9,
                            Name = "Member 9",
                            Email = "member9@example.com",
                            Phone = "9012345678",
                            Password = "password9"
                        },
                        new Member {
                            //MemberId = 10,
                            Name = "Member 10",
                            Email = "member10@example.com",
                            Phone = "0123456789",
                            Password = "password10"
                        },
                        new Member {
                            //MemberId = 11, 
                            Name = "Member 11",
                            Email = "member11@example.com",
                            Phone = "1234567890",
                            Password = "password11"
                        },
                        new Member {
                            //MemberId = 12,
                            Name = "Member 12",
                            Email = "member12@example.com",
                            Phone = "2345678901",
                            Password = "password12"
                        },
                        new Member {
                            //MemberId = 13,
                            Name = "Member 13",
                            Email = "member13@example.com",
                            Phone = "3456789012",
                            Password = "password13"
                        },
                        new Member {
                            //MemberId = 14,
                            Name = "Member 14",
                            Email = "member14@example.com",
                            Phone = "4567890123",
                            Password = "password14"
                        },
                        new Member {
                            //MemberId = 15,
                            Name = "Member 15",
                            Email = "member15@example.com",
                            Phone = "5678901234",
                            Password = "password15"
                        },
                        new Member {
                            //MemberId = 16,
                            Name = "Member 16",
                            Email = "member16@example.com",
                            Phone = "6789012345",
                            Password = "password16"
                        },
                        new Member {
                            //MemberId = 17, 
                            Name = "Member 17",
                            Email = "member17@example.com",
                            Phone = "7890123456",
                            Password = "password17"
                        },
                        new Member {
                            //MemberId = 18,
                            Name = "Member 18",
                            Email = "member18@example.com",
                            Phone = "8901234567",
                            Password = "password18"
                        },
                        new Member {
                            //MemberId = 19, 
                            Name = "Member 19",
                            Email = "member19@example.com",
                            Phone = "9012345678",
                            Password = "password19"
                        },
                        new Member {
                            //MemberId = 20,
                            Name = "Member 20",
                            Email = "member20@example.com",
                            Phone = "0123456789",
                            Password = "password20"
                        },
                        new Member { 
                            //MemberId = 21,
                            Name = "Member 21",
                            Email = "member21@example.com",
                            Phone = "1234567890",
                            Password = "password21"
                        },
                        new Member {
                            //MemberId = 22,
                            Name = "Member 22",
                            Email = "member22@example.com",
                            Phone = "2345678901",
                            Password = "password22"
                        },
                        new Member {
                            //MemberId = 23,
                            Name = "Member 23",
                            Email = "member23@example.com",
                            Phone = "3456789012",
                            Password = "password23"
                        },
                        new Member {
                            //MemberId = 24,
                            Name = "Member 24",
                            Email = "member24@example.com",
                            Phone = "4567890123",
                            Password = "password24"
                        },
                        new Member {
                            //MemberId = 25,
                            Name = "Member 25",
                            Email = "member25@example.com",
                            Phone = "5678901234",
                            Password = "password25"
                        },
                        new Member {
                            //MemberId = 26, 
                            Name = "Member 26",
                            Email = "member26@example.com",
                            Phone = "6789012345",
                            Password = "password26"
                        },
                        new Member {
                            //MemberId = 27,
                            Name = "Member 27",
                            Email = "member27@example.com",
                            Phone = "7890123456",
                            Password = "password27"
                        },
                        new Member {
                            //MemberId = 28,
                            Name = "Member 28",
                            Email = "member28@example.com",
                            Phone = "8901234567",
                            Password = "password28"
                        },
                        new Member {
                            //MemberId = 29,
                            Name = "Member 29",
                            Email = "member29@example.com",
                            Phone = "9012345678",
                            Password = "password29"
                        },
                        new Member {
                            //MemberId = 30,
                            Name = "Member 30",
                            Email = "member30@example.com",
                            Phone = "0123456789",
                            Password = "password30"
                        },
                        new Member {
                            //MemberId = 31,
                            Name = "Admin",
                            Email = "Admin@example.com",
                            Phone = "0123456781",
                            Password = "password31"
                        }

                    });
                    context.SaveChanges();
                }
                //Voting
                if (!context.Votings.Any())
                {
                    context.Votings.AddRange(new List<Voting>()
                    {
                        new Voting { 
                            //VotingId = 1, 
                            MeetingId = 5,
                            Question = "Question 1"
                        },
                        new Voting { 
                            //VotingId = 2, 
                            MeetingId = 6,
                            Question = "Question 2"
                        },
                        new Voting {
                            //VotingId = 3,
                            MeetingId = 7,
                            Question = "Question 3"
                        },
                        new Voting {
                            //VotingId = 4, 
                            MeetingId = 8,
                            Question = "Question 4"
                        },
                        new Voting {
                            //VotingId = 5, 
                            MeetingId = 9,
                            Question = "Question 5"
                        },
                        new Voting {
                            //VotingId = 6,
                            MeetingId = 10,
                            Question = "Question 6"
                        },
                        new Voting {
                            //VotingId = 7,
                            MeetingId = 11,
                            Question = "Question 7"
                        },
                        new Voting {
                            //VotingId = 8, 
                            MeetingId = 12,
                            Question = "Question 8"
                        },
                        new Voting {
                            //VotingId = 9,
                            MeetingId = 13,
                            Question = "Question 9"
                        },
                        new Voting {
                            //VotingId = 10,
                            MeetingId = 14,
                            Question = "Question 10"
                        }

                    });
                    context.SaveChanges();
                }
                //Report
                if (!context.Reports.Any())
                {
                    context.Reports.AddRange(new List<Report>()
                    {
                        new Report { 
                            //ReportId = 1,
                            Description = "Report 1 Description",
                            MeetingId = 5
                        },
                        new Report {
                            //ReportId = 2, 
                            Description = "Report 2 Description",
                            MeetingId = 6
                        },
                        new Report { 
                            //ReportId = 3, 
                            Description = "Report 3 Description",
                            MeetingId = 7
                        },
                        new Report {
                            //ReportId = 4,
                            Description = "Report 4 Description",
                            MeetingId = 8
                        },
                        new Report {
                            //ReportId = 5,
                            Description = "Report 5 Description",
                            MeetingId = 9
                        },
                        new Report { 
                            //ReportId = 6,
                            Description = "Report 6 Description",
                            MeetingId = 10
                        },
                        new Report { 
                            //ReportId = 7,
                            Description = "Report 7 Description",
                            MeetingId = 11
                        },
                        new Report {
                            //ReportId = 8,
                            Description = "Report 8 Description",
                            MeetingId = 12
                        },
                        new Report {
                            //ReportId = 9, 
                            Description = "Report 9 Description",
                            MeetingId = 13
                        },
                        new Report {
                            //ReportId = 10,
                            Description = "Report 10 Description",
                            MeetingId = 14
                        }

                    });
                    context.SaveChanges();
                }
                //MemberCommittee
                if (!context.MemberCommittees.Any())
                {
                    context.MemberCommittees.AddRange(new List<MemberCommittee>()
                    {
                        new MemberCommittee { 
                           // Id = 1, 
                            CommitteeId = 5,
                            MemberId = 1,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 1, 
                            CommitteeId = 8,
                            MemberId = 1,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 1, 
                            CommitteeId = 9,
                            MemberId = 1,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 1, 
                            CommitteeId = 6,
                            MemberId = 1,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 2, 
                            CommitteeId = 5,
                            MemberId = 2,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 3,
                            CommitteeId = 5,
                            MemberId = 3,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 4, 
                            CommitteeId = 6,
                            MemberId = 4,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 5,
                            CommitteeId = 6,
                            MemberId = 5,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 6, 
                            CommitteeId = 6,
                            MemberId = 6,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 7, 
                            CommitteeId = 7,
                            MemberId = 7,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 8, 
                            CommitteeId = 7,
                            MemberId = 8,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 9,
                            CommitteeId = 7,
                            MemberId = 9,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 10,
                            CommitteeId = 8,
                            MemberId = 10,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 11, 
                            CommitteeId = 8,
                            MemberId = 11,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 12, 
                            CommitteeId = 8,
                            MemberId = 12,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 13, 
                            CommitteeId = 9,
                            MemberId = 13,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 14, 
                            CommitteeId = 9,
                            MemberId = 14,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 15, 
                            CommitteeId = 9,
                            MemberId = 15,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 16, 
                            CommitteeId = 5,
                            MemberId = 16,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 17,
                            CommitteeId = 6,
                            MemberId = 17,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 18, 
                            CommitteeId = 7,
                            MemberId = 18,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 19,
                            CommitteeId = 8,
                            MemberId = 19,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 20,
                            CommitteeId = 9,
                            MemberId = 20,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 21,
                            CommitteeId = 5,
                            MemberId = 21,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 22, 
                            CommitteeId = 6,
                            MemberId = 22,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 23,
                            CommitteeId = 7,
                            MemberId = 23,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 24,
                            CommitteeId = 8,
                            MemberId = 24,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 25,
                            CommitteeId = 9,
                            MemberId = 25,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 26,
                            CommitteeId = 5,
                            MemberId = 26,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 27,
                            CommitteeId = 6,
                            MemberId = 27,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                           // Id = 28,
                            CommitteeId = 7,
                            MemberId = 28,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 29,
                            CommitteeId = 8,
                            MemberId = 29,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                           // Id = 30, 
                            CommitteeId = 9,
                            MemberId = 30,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        }

                    });
                    context.SaveChanges();
                }
                //MemberMeeting
                if (!context.MemberMeeting.Any())
                {
                    context.MemberMeeting.AddRange(new List<MemberMeeting>()
                    {
                        new MemberMeeting
                        {
                            //MemberMeetingId = 1,
                            MemberId = 1,
                            MeetingId = 5,
                            Response = State.Attend,
                        },
                        new MemberMeeting
                        {
                            //MemberMeetingId = 2,
                            MemberId = 1,
                            MeetingId = 6,
                            Response = State.Execuse,
                        },
                        new MemberMeeting
                        {
                            //MemberMeetingId = 3,
                            MemberId = 2,
                            MeetingId = 5,
                            Response = State.Attend,
                        },
                        new MemberMeeting
                        {
                           // MemberMeetingId = 4,
                            MemberId = 2,
                            MeetingId = 6,
                            Response = State.Attend,
                        },
                        new MemberMeeting
                        {
                           // MemberMeetingId = 5,
                            MemberId = 3,
                            MeetingId = 5,
                            Response = State.Attend,
                        },
                        new MemberMeeting
                        {
                           // MemberMeetingId = 6,
                            MemberId = 3,
                            MeetingId = 6,
                            Response = State.NotAnswerd,
                        },
                    });
                    context.SaveChanges();
                }
                //Member Answer
                if (!context.MembersAnswers.Any())
                {
                    context.MembersAnswers.AddRange(new List<MemberAnswers>()
                    {
                        new MemberAnswers
                        {
                           // Id = 1,
                            VotingId = 1,
                            MeetingId = 5,
                            MemberId = 1,
                            CommitteeId = 5,
                            Comment = "موافق"
                        },
                        new MemberAnswers
                        {
                           // Id = 2,
                            VotingId = 1,
                            MeetingId = 5,
                            MemberId = 2,
                            CommitteeId = 5,
                            Comment = "غير موافق"
                        },
                        new MemberAnswers
                        {
                           // Id = 3,
                            VotingId = 1,
                            MeetingId = 5,
                            MemberId = 3,
                            CommitteeId = 5,
                            Comment = "ممتنع"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
