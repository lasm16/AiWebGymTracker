using AiWebGymTracker.Abstractions;
using AiWebGymTracker.DAL;
using AiWebGymTracker.Extensions;
using AiWebGymTracker.HostedServices;
using AiWebGymTracker.Infrastructure.Configurations;
using AiWebGymTracker.Infrastructure.Configurers;
using AiWebGymTracker.Infrastructure.Services;
using AiWebGymTracker.Middleware;
using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Reflection;

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

            builder.Services.AddTransient<IAiService, YandexAiService>();

            builder.Services.Configure<YandexConfiguration>(builder.Configuration.GetSection("YandexConfiguration"));

            builder.Services.AddHttpClient(AiServiceName.YandexAi.ToString(), (serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<YandexConfiguration>>();
                client.BaseAddress = new Uri(options.Value.Uri);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Api-Key", options.Value.ApiAuthorization);
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                options.RoutePrefix = "api";
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
