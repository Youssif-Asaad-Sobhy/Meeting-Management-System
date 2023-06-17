using Meeting_Manegment_System.Data.Static;
using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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

                //Committee
                if (!context.Committee.Any())
                {
                    context.Committee.AddRange(new List<Committee>()
                    {
                        new Committee
                        {
                            CommitteeId = 1,
                            OrganizationId = 1,
                            Name = "أعضاء هيئة التدريس",
                            Description = "Descrbtion 1",
                        },
                        new Committee
                        {
                            CommitteeId = 2,
                            OrganizationId = 1,
                            Name = "اداريين",
                            Description = "هذه اللجنة تضم موظفين سؤون الطلاب وموظفين المكتبة والموارد البشرية واداريين الكلية  ",
                        }
                    });
                    context.SaveChanges();
                }
                //Meeting
                if (!context.Meeting.Any())
                {
                    context.Meeting.AddRange(new List<Meeting>()
                    {
                        new Meeting
                        {
                            MeetingId = 1,
                            CommitteeId = 1,
                            Goal = "Goal 1",
                            Emergency = false,
                            Date = DateTime.Now
                        },
                        new Meeting
                        {
                            MeetingId = 2,
                            CommitteeId = 1,
                            Goal = "Goal 2",
                            Emergency = true,
                            Date = DateTime.Now.AddMonths(1)
                        },
                        new Meeting
                        {
                            MeetingId = 3,
                            CommitteeId = 2,
                            Goal = "Goal 3",
                            Emergency = false,
                            Date = DateTime.Now
                        }
                    });
                    context.SaveChanges();
                }
                ///Member
                if (!context.Member.Any())
                {
                    context.Member.AddRange(new List<Member>()
                    {
                        new Member
                        {
                            MemberId = 1,
                            Name = "Mohamed Osama",
                            Email = "Moh@Example.com",
                            Phone = "0123456789",
                            Password = "Mohamed@123"
                        },
                        new Member
                        {
                            MemberId = 2,
                            Name = "Zeyad Abdelnaby",
                            Email = "Zeyad@Example.com",
                            Phone = "0115432115",
                            Password = "Zeyad@123"
                        },
                        new Member
                        {
                            MemberId = 3,
                            Name = "Youssef Asaad",
                            Email = "Youssef@Example.com",
                            Phone = "0987654321",
                            Password = "Youssed@123"
                        }
                    });
                    context.SaveChanges();
                }
                //Member Answer
                if (!context.MembersAnswers.Any())
                {
                    context.MembersAnswers.AddRange(new List<MemberAnswers>()
                    {
                        new MemberAnswers {
                            Id = 1,
                            VotingId = 1,
                            MeetingId = 1,
                            MemberId = 1,
                            CommitteeId = 1
                        },
                        new MemberAnswers {
                            Id = 2,
                            VotingId = 1,
                            MeetingId = 1,
                            MemberId = 2,
                            CommitteeId = 1
                        },
                        new MemberAnswers {
                            Id = 3,
                            VotingId = 2,
                            MeetingId = 2,
                            MemberId = 3,
                            CommitteeId = 2
                        },
                    });
                    context.SaveChanges();
                }
                //Member Committee
                if (!context.MemberCommittees.Any())
                {
                    context.MemberCommittees.AddRange(new List<MemberCommittee>()
                    {
                         new MemberCommittee
                         {
                             Id = 1,
                             CommitteeId = 1,
                             MemberId = 1,
                             Role = RoleType.Member,
                             StartDate = DateTime.Now,
                             EndDate = DateTime.Now.AddYears(4)
                         },
                         new MemberCommittee
                         {
                             Id = 2,
                             CommitteeId = 2,
                             MemberId = 2,
                             Role = RoleType.President,
                             StartDate = DateTime.Now,
                             EndDate = DateTime.Now.AddYears(4)
                         },
                    });
                    context.SaveChanges();
                }
                //Member Meeting
                if (!context.MemberMeeting.Any())
                {
                    context.MemberMeeting.AddRange(new List<MemberMeeting>()
                    {
                        new MemberMeeting
                        {
                            MemberMeetingId = 1,
                            MemberId = 1,
                            MeetingId = 1,
                            Response = State.Attend
                        },
                        new MemberMeeting
                        {
                            MemberMeetingId = 2,
                            MemberId = 2,
                            MeetingId = 2,
                            Response = State.Execuse
                        },
                        new MemberMeeting
                        {
                            MemberMeetingId = 3,
                            MemberId = 2,
                            MeetingId = 1,
                            Response = State.Attend
                        },
                    });
                    context.SaveChanges();
                }

                //Organization
                if (!context.Organizations.Any())
                {
                    context.Organizations.AddRange(new List<Organization>()
                    {
                        new Organization
                        {
                            OrganizationId = 1,
                            Name = "Organization 1"
                        },
                    });
                    context.SaveChanges();
                }
                //Report
                if (!context.Reports.Any())
                {
                    context.Reports.AddRange(new List<Report>()
                    {
                        new Report
                        {
                            ReportId = 1,
                            Description = "Report 1",
                            MeetingId = 1
                        },
                        new Report
                        {
                            ReportId = 2,
                            Description = "Report 2",
                            MeetingId = 2
                        },
                    });
                }
                //Voting
                if (!context.Votings.Any())
                {
                    context.Votings.AddRange(new List<Voting>()
                    {
                         new Voting
                         {
                             VotingId = 1,
                             MeetingId = 1,
                             Question = "Question 1"
                         },
                         new Voting
                         {
                             VotingId = 2,
                             MeetingId = 2,
                             Question = "Question 2"
                         },
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRoles(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // roles
                var roleManager = servicescope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // users
                var userManager = servicescope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "adminUser@MeetingManagment.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "User@MeetingManagment.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }


                string PresedintUserEmail = "Presedint@MeetingManagment.com";
                var PresedintUser = await userManager.FindByEmailAsync(PresedintUserEmail);
                if (PresedintUser == null)
                {
                    var newPresedintUser = new ApplicationUser()
                    {
                        FullName = "Presedint User",
                        UserName = "Presedint-user",
                        Email = PresedintUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newPresedintUser, "Presedint@123");
                    await userManager.AddToRoleAsync(newPresedintUser, UserRoles.Presedint);
                }



                string VicePresedintUserEmail = "VicePresedint@MeetingManagment.com";
                var VicePresedintUser = await userManager.FindByEmailAsync(VicePresedintUserEmail);
                if (VicePresedintUser == null)
                {
                    var newVicePresedintUser = new ApplicationUser()
                    {
                        FullName = "Vice Presedint User",
                        UserName = "Vice-Presedint-user",
                        Email = VicePresedintUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newVicePresedintUser, "VicePresedint@123");
                    await userManager.AddToRoleAsync(newVicePresedintUser, UserRoles.VicePresedint);
                }
            }
        }
    }
}