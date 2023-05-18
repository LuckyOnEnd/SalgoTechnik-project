using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SalgoTechnik.Application.Interfaces;
using SalgoTechnik.Application.Services;
using SalgoTechnik.Domain.Entities;
using SalgoTechnik.Infastructure;
using SalgoTechnik.Infastructure.Repository;
using System.Globalization;
using System.Reflection;

namespace SalgoTechnik.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ru-RU")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "en-Us", uiCulture: "en-Us");
                options.SupportedUICultures = supportedCultures;
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityCore<AppUser>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddDefaultTokenProviders();

            builder.Services.AddSingleton<LanguageService>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IReferenceService, ReferenceService>();

            var app = builder.Build();

            app.UseRequestLocalization();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}