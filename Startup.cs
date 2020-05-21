using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MvcMeetcha.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MvcMeetcha
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcMeetchaContext")));

            services
                .AddIdentity<Account, IdentityRole>(options =>
                    options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppDbContext>()
                // Support token generation for reseting email
                .AddDefaultTokenProviders();

            services
                .AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    // All pages under Identity/Pages/Account/Manage need authorization
                    options.Conventions.AuthorizeFolder("/BackOffice");
                });

            services.ConfigureApplicationCookie(options =>
            {
                // Redirect to this path when authentication is needed
                options.LoginPath = "/BackOffice/Login";
                options.LogoutPath = "/BackOffice/Logout";
                options.AccessDeniedPath = "/BackOffice/AccessDenied";
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // Enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                /*
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                */
            });
        }
    }
}
