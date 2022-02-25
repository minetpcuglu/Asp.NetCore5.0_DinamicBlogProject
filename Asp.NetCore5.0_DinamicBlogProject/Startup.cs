using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_DinamicBlogProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //authorzie i�in yap�land�rma yapma
        {


            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();





            services.AddControllersWithViews();
            //services.AddTransient<UserManager<AppUser>>();
            //services.AddTransient<UserManager<AppRole>>();
            services.AddSession();//session yonetimi i�in.


            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    config.Filters.Add(new AuthorizeFilter(policy)); //proje seviyesinde authorize yetkilendirme i�lemi
            //});


            //services.AddAuthentication(
            //    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            //    {
            //        x.LoginPath = "/RegisterUser/SignIn/";
            //    }
            //    );



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //hata sayfas� kullan�m tan�m�
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();//session y�netimi i�in

            app.UseRouting();

            app.UseAuthentication(); //login 

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=RegisterUser}/{action=SignIn}/{id?}");
            });


            //        < system.webServer >
            //< modules runAllManagedModulesForAllRequests = "true" >

            //     < remove name = "WebDAVModule" /> < !--bunu ekliyoruz-- >

            //     </ modules >

            //     < handlers >

            //         < remove name = "WebDAV" /> < !--bunu ekliyoruz-- >

            //        </ handlers >
            //    </ system.webServer >
        }
    }
}
