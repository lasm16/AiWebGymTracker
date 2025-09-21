using AiWebGymTracker.DAL;
using AiWebGymTracker.DAL.Repositories;
using AiWebGymTracker.DAL.Repositories.Abstractions;
using AiWebGymTracker.Extensions;
using AiWebGymTracker.HostedServices;
using AiWebGymTracker.Infrastructure.Abstractions;
using AiWebGymTracker.Infrastructure.Configurations;
using AiWebGymTracker.Infrastructure.Services;
using AiWebGymTracker.Middleware;
using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = builder.Configuration["CookieSettings:LoginPath"];
                options.AccessDeniedPath = builder.Configuration["CookieSettings:AccessDeniedPath"];
            });
    
            builder.Services.AddAuthentication().AddCookie();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICustomMessageProvider, CustomMessageService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureAppCookie>();

            //builder.Services.AddTransient<IAiService, YandexAiService>();

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
            // Автоматическое применение миграций
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.Migrate(); // Применяет миграции автоматически
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

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
            
            //Проверка подключения к базе данных
            try
            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var canConnect = context.Database.CanConnect();
                Console.WriteLine($"Database connection: {canConnect}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
            }
            app.Run();
        }
    }
}
