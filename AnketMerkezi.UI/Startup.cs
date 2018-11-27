using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnketMerkezi.Data.ORM.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnketMerkezi.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/giris-yap";
        });
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(@"Server=DESKTOP-CE1GVBQ\SQLEXPRESS;Database=AnketMerkeziDB;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc(routes =>
            {

                #region Panel

                routes.MapRoute(
                 name: "UpgradeAccount",
                 template: "panel/hesap-yukselt",
                 defaults: new { controller = "Panel", action = "UpgradeAccount" });

                routes.MapRoute(
                 name: "UsageQuota",
                 template: "panel/kullanim-kotasi",
                 defaults: new { controller = "Panel", action = "UsageQuota" });

                routes.MapRoute(
                 name: "Dashboard",
                 template: "panel/genel-durum",
                 defaults: new { controller = "Panel", action = "Index" });

                routes.MapRoute(
                 name: "Settings",
                 template: "panel/ayarlar",
                 defaults: new { controller = "Panel", action = "Settings" });

                #endregion

                #region User

                routes.MapRoute(
                 name: "Register",
                 template: "kayit-ol",
                 defaults: new { controller = "User", action = "Register" });

                routes.MapRoute(
                 name: "Login",
                 template: "giris-yap",
                 defaults: new { controller = "User", action = "Login" });

                #endregion

                #region Survey


                routes.MapRoute(
                name: "EditSurvey",
                template: "panel/anket-duzenle/{link}",
                defaults: new { controller = "Survey", action = "Edit" });

                routes.MapRoute(
                name: "ShareSurvey",
                template: "panel/anket-paylas",
                defaults: new { controller = "Survey", action = "Share" });

                routes.MapRoute(
                 name: "Surveys",
                 template: "panel/anket-listesi",
                 defaults: new { controller = "Survey", action = "Index" });

                routes.MapRoute(
                 name: "AddSurvey",
                 template: "panel/anket-ekle",
                 defaults: new { controller = "Survey", action = "Add" });

                #endregion

                #region SupportRequest

                routes.MapRoute(
                 name: "AddSupportRequest",
                 template: "panel/destek-talep-ekle",
                 defaults: new { controller = "SupportRequest", action = "Add" });

                routes.MapRoute(
                 name: "SupportRequests",
                 template: "panel/destek-talep-listesi",
                 defaults: new { controller = "SupportRequest", action = "Index" });

                #endregion

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
        }
    }
}
