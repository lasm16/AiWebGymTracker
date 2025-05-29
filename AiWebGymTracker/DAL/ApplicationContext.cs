using AiWebGymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Nutrition> Nutrition { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
