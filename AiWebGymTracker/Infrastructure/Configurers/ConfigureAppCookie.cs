using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace AiWebGymTracker.Infrastructure.Configurers;

public class ConfigureAppCookie(IConfiguration configuration) : IConfigureOptions<CookieAuthenticationOptions>
{
    public void Configure(CookieAuthenticationOptions options)
    {
        options.LoginPath = configuration["CookieSettings:LoginPath"];
        options.AccessDeniedPath = configuration["CookieSettings:AccessDeniedPath"];
    }
}