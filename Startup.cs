using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_Basics__Assignment.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MVC_Basics__Assignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;

namespace MVC_Basics__Assignment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
                .AddV8();

            services.AddMvc();

            services.AddDbContext<PeopleDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<PeopleDatabaseContext>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseReact(config =>
            {
                //config.AddScript("file");
            }
            );
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PeopleDB",
                    pattern: "/PeopleDB",
                    defaults: new { controller = "PeopleDB", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "Ajax",
                    pattern: "/Ajax",
                    defaults: new { controller = "Ajax", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "People",
                    pattern: "/People",
                    defaults: new { controller = "People", action = "People" });
                endpoints.MapControllerRoute(
                    name: "GuessingGame",
                    pattern: "/GuessingGame",
                    defaults: new { controller = "GuessingGame", action = "GuessingGame" });
                endpoints.MapControllerRoute(
                    name: "Doctor",
                    pattern: "/FeverCheck",
                    defaults: new { controller = "Doctor", action = "FeverCheck" });
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
