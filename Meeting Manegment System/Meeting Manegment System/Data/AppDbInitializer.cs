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
                            //CommitteeId = 3,
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
                            Emergency = false,
                            Name="Meet 1",
                            Place = "online",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(2)
                        },
                        new Meeting {
                            //MeetingId = 2, 
                            CommitteeId = 5,
                            Goal = "Goal 2",
                            Emergency = true,
                            Name="Meet 2",
                            Place = "online",
                            StartDate = new DateTime(2023, 6, 15, 9, 30, 0, 0),
                            EndDate = new DateTime(2023, 6, 15, 11, 30, 0, 0)
                        },
                        new Meeting { 
                            //MeetingId = 3, 
                            CommitteeId = 5,
                            Goal = "Goal 3",
                            Emergency = false,
                            Name="Meet 3",
                            Place = "online",
                            StartDate = new DateTime(2023, 6, 20, 14, 30, 0, 0),
                            EndDate = new DateTime(2023, 6, 20, 16, 30, 0, 0)
                        },
                        new Meeting { 
                            //MeetingId = 4,
                            CommitteeId = 5,
                            Goal = "Goal 4",
                            Emergency = false,
                            Name="Meet 4",
                            Place = "online",
                            StartDate = new DateTime(2023, 5, 12, 9, 30, 0, 0),
                            EndDate = new DateTime(2023, 5, 13, 11, 30, 0, 0)
                        },
                        new Meeting {
                            //MeetingId = 5,
                            CommitteeId = 4,
                            Goal = "Goal 5",
                            Emergency = true,
                            Name="Meet 5",
                            Place = "offline",
                            StartDate = new DateTime(2023, 7, 17, 9, 30, 0, 0),
                            EndDate = new DateTime(2023, 7, 18, 11, 30, 0, 0)
                        },
                        new Meeting {
                            //MeetingId = 6,
                            CommitteeId = 4,
                            Goal = "Goal 6",
                            Emergency = false,
                            Name="Meet 6",
                            Place = "FCI",
                            StartDate = new DateTime(2023, 9, 21, 9, 30, 0, 0),
                            EndDate = new DateTime(2023, 9, 23, 11, 30, 0, 0)
                        },
                        new Meeting {
                            //MeetingId = 7, 
                            CommitteeId = 3,
                            Goal = "Goal 7",
                            Emergency = false,
                            Name="Meet 7",
                            Place = "online",
                            StartDate = new DateTime(2023, 10, 11, 9, 30, 0, 0),
                            EndDate = new DateTime(2023, 10, 13, 11, 30, 0, 0)
                        },
                        new Meeting { 
                            //MeetingId = 8,
                            CommitteeId = 2,
                            Goal = "Goal 8",
                            Emergency = true,
                            Name="Meet 8",
                            Place = "online",
                            StartDate = new DateTime(2023, 12, 2, 9, 30, 0, 0),
                            EndDate = new DateTime(2023, 12, 3, 11, 30, 0, 0)
                        },
                        new Meeting {
                            //MeetingId = 9,
                            CommitteeId = 1,
                            Goal = "Goal 9",
                            Emergency = false,
                            Name="Meet 9",
                            Place = "onsite",
                            StartDate = new DateTime(2023, 12, 31, 9, 30, 0, 0),
                            EndDate = new DateTime(2024, 1, 6, 11, 30, 0, 0)
                        },
                        new Meeting { 
                            //MeetingId = 10,
                            CommitteeId = 2,
                            Goal = "Goal 10",
                            Emergency = true,
                            Name="Meet 10",
                            Place = "onsite",
                            StartDate = new DateTime(2023, 3, 3, 9, 30, 0, 0),
                            EndDate = new DateTime(2023, 3, 6, 11, 30, 0, 0)
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
                            VotingId = 1, 
                            MeetingId = 1,
                            Question = "Question 1"
                        },
                        new Voting { 
                            VotingId = 2, 
                            MeetingId = 2,
                            Question = "Question 2"
                        },
                        new Voting {
                            VotingId = 3,
                            MeetingId = 3,
                            Question = "Question 3"
                        },
                        new Voting {
                            VotingId = 4, 
                            MeetingId = 4,
                            Question = "Question 4"
                        },
                        new Voting {
                            VotingId = 5, 
                            MeetingId = 5,
                            Question = "Question 5"
                        },
                        new Voting {
                            VotingId = 6,
                            MeetingId = 1,
                            Question = "Question 6"
                        },
                        new Voting {
                            VotingId = 7,
                            MeetingId = 2,
                            Question = "Question 7"
                        },
                        new Voting {
                            VotingId = 8, 
                            MeetingId = 3,
                            Question = "Question 8"
                        },
                        new Voting {
                            VotingId = 9,
                            MeetingId = 4,
                            Question = "Question 9"
                        },
                        new Voting {
                            VotingId = 10,
                            MeetingId = 5,
                            Question = "Question 10"
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
                            CommitteeId = 1,
                            MemberId = 1,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 1, 
                            CommitteeId = 1,
                            MemberId = 2,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 1, 
                            CommitteeId = 1,
                            MemberId = 3,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                           // Id = 1, 
                            CommitteeId = 1,
                            MemberId = 4,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 4, 
                            CommitteeId = 2,
                            MemberId = 2,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 3,
                            CommitteeId = 2,
                            MemberId = 3,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 2, 
                            CommitteeId = 2,
                            MemberId = 4,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 2, 
                            CommitteeId = 2,
                            MemberId = 1,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 4, 
                            CommitteeId = 3,
                            MemberId = 3,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 3,
                            CommitteeId = 3,
                            MemberId = 4,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 2, 
                            CommitteeId = 3,
                            MemberId = 1,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 2, 
                            CommitteeId = 3,
                            MemberId = 2,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 4, 
                            CommitteeId = 4,
                            MemberId = 4,
                            Role = RoleType.President,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                            //Id = 3,
                            CommitteeId = 4,
                            MemberId = 1,
                            Role = RoleType.Secretary,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 2, 
                            CommitteeId = 4,
                            MemberId = 2,
                            Role = RoleType.Vice,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee { 
                            //Id = 2, 
                            CommitteeId = 4,
                            MemberId = 3,
                            Role = RoleType.Member,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30)
                        },
                        new MemberCommittee {
                           // Id = 30, 
                            CommitteeId = 4,
                            MemberId = 31,
                            Role = RoleType.Admin,
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
                //if (!context.MembersAnswers.Any())
                //{
                //    context.MembersAnswers.AddRange(new List<MemberAnswers>()
                //    {
                //        new MemberAnswers
                //        {
                //           // Id = 1,
                //            VotingId = 1,
                //            MeetingId = 1,
                //            MemberId = 1,
                //            CommitteeId = 3,
                //            Comment = "موافق"
                //        },
                //        new MemberAnswers
                //        {
                //           // Id = 2,
                //            VotingId = 1,
                //            MeetingId = 2,
                //            MemberId = 2,
                //            CommitteeId = 2,
                //            Comment = "غير موافق"
                //        },
                //        new MemberAnswers
                //        {
                //           // Id = 3,
                //            VotingId = 1,
                //            MeetingId = 3,
                //            MemberId = 3,
                //            CommitteeId = 1,
                //            Comment = "ممتنع"
                //        }
                //    });
                //    context.SaveChanges();
                //}
            }
        }
    }
}
