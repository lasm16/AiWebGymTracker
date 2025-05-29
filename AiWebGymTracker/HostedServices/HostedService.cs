using AiWebGymTracker.DAL;
using AiWebGymTracker.Models;

namespace AiWebGymTracker.HostedServices
{
    /// <summary>
    /// Для проверки работоспособности подключенной базы базы
    /// </summary>
    public class HostedService : BackgroundService
    {
        private readonly IServiceProvider _sp;

        public HostedService(IServiceProvider sp) 
        { 
            _sp = sp;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _sp.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var model = new Dish()
                    {
                        Id = 0,
                        Weight = 100 * new Random().Next()
                    };

                    var nutritions = context.Dishes.ToList();

                    var added = await context.Dishes.AddAsync(model);

                    await context.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
