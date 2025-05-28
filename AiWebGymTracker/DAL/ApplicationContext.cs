using AiWebGymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
