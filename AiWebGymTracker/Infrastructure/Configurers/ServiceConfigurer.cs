using AiWebGymTracker.Abstractions;
using AiWebGymTracker.DAL;
using AiWebGymTracker.Infrastructure.Services;
using AiWebGymTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.Infrastructure.Configurers;

internal static class ServiceConfigurer
{
    internal static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.Configure<IdentityOptions>(configuration.GetSection("IdentityOptions"));

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = configuration["CookieSettings:LoginPath"];
            options.AccessDeniedPath = configuration["CookieSettings:AccessDeniedPath"];
        });

        services.AddAuthentication().AddCookie();
        services.AddScoped<IAccountService, AccountService>();

    }
}