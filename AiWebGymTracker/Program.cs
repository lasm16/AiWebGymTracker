using AiWebGymTracker.Abstractions;
using AiWebGymTracker.DAL;
using AiWebGymTracker.Extensions;
using AiWebGymTracker.HostedServices;
using AiWebGymTracker.Infrastructure.Configurers;
using AiWebGymTracker.Infrastructure.Services;
using AiWebGymTracker.Middleware;
using AiWebGymTracker.Models;
using AiWebGymTracker.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AiWebGymTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();

            builder.Services.AddHostedService<HostedService>();

            builder.Services.RegisterContext(builder.Configuration);

            builder.Services.Configure<IdentityOptions>(builder.Configuration.GetSection("IdentityOptions"));
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
    
            builder.Services.AddAuthentication().AddCookie();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureAppCookie>();
    
            var app = builder.Build();
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
    
            app.Run();
        }
    }
}
