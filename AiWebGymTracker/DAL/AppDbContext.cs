using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;
using AiWebGymTracker.Models.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.DAL;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Nutrition> Nutritions { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseTraining> ExerciseTrainings { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToLower());
        }        
    }

    
}
