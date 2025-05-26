using AiWebGymTracker.Infrastructure.Configurers;

namespace AiWebGymTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ServiceConfigurer.Configure(builder.Services, builder.Configuration);
            
            var app = builder.Build();
            MiddlewareConfigurer.Configure(app);
            
            app.Run();
        }
    }
}
