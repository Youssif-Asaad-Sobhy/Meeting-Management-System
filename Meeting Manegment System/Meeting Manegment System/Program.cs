using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;
using Meeting_Manegment_System.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefualtConnectionString")
    ));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(120); });
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IVotingRepository, VotingRepository>();
builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<ICommitteeRepository, CommitteeRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IMemberAnswerRepository, MemberAnswerRepository>();
builder.Services.AddScoped<IMemberMeetingRepository, MemberMeetingRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRctorepository>();
builder.Services.AddScoped<IMemberCommitteeRepository, MemberCommitteeRepository>();

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddRoles<IdentityRole>() // Register the RoleManager<IdentityRole> service
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<ISystemClock, SystemClock>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

//Seed DataBase
AppDbInitializer.Seed(app);
await AppDbInitializer.SeedUsersAndRulesAsync(app);



app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
