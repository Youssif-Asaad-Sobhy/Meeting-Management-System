using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Manegment_System
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddMemoryCache();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefualtConnectionString")));

            // Register UserManager<ApplicationUser> service
            //services.AddScoped<UserManager<ApplicationUser>>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();


            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<SignInManager<ApplicationUser>>();

            // Register SignInManager<ApplicationUser> service
            services.AddScoped<SignInManager<ApplicationUser>>();

            services.AddControllersWithViews();
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppDbInitializer.SeedUsersAndRulesAsync(app).Wait();

            // Configure middleware and other app-specific configurations
        }
    }

}
