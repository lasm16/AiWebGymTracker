using AiWebGymTracker.DAL;
using Microsoft.EntityFrameworkCore;

namespace AiGymTracker.WebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Npgsql");

            services.AddDbContext<ApplicationContext>(x => x.UseNpgsql(connectionString));

            return services;
        }
    }
}
