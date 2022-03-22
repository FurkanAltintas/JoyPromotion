using FluentValidation.AspNetCore;
using JoyPromotion.Business.IOC.Microsoft;
using JoyPromotion.Shared.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace JoyPromotion.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "JoyPromotion"; // Cookie'nin taray�c�da g�z�kece�i ad�
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict; // Di�er web sitelerin cookie kullan�m�n� kapad�k
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Bu cookie hem https de hem de http de �al��acak
                options.ExpireTimeSpan = TimeSpan.FromDays(20); // Kullan�c�n�n ilgili bilgileri 20 g�n boyunca hayatta kal�cak
                options.LoginPath = new PathString("/Auth/Login");
            });

            // services.AddSession();
            // services.AddDistributedMemoryCache();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddCustomDependencies(Configuration);

            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // app.UseSession();

            app.UseRouting();

            app.UseAuthentication(); // giri� i�lemi
            app.UseAuthorization(); // yetki i�lemi

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "admin", pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "content",
                    pattern: "{controller=Home}/{title}-{id}",
                    defaults: new { controller = "Home", action = "Details" });

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
