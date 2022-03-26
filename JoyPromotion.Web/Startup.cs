using FluentValidation.AspNetCore;
using JoyPromotion.Business.IOC.Microsoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            // app.UseSession();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication(); // giriþ iþlemi
            app.UseAuthorization(); // yetki iþlemi

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
