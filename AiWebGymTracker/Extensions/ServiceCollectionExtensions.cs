using AiWebGymTracker.DAL;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Npgsql");

            services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));

            return services;
        }
    }
}
