using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;
using AiWebGymTracker.Models.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

        modelBuilder.Entity<ExerciseTraining>()
        .HasOne(et => et.Exercise)
        .WithMany(e => e.ExerciseTrainings)
        .HasForeignKey(et => et.ExerciseId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExerciseTraining>()
            .HasOne(et => et.Training)
            .WithMany(t => t.ExerciseTrainings)
            .HasForeignKey(et => et.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);      

        modelBuilder.Entity<Training>()
        .Property(t => t.DateTimeStart)
        .HasColumnType("timestamp without time zone");

        modelBuilder.Entity<Training>()
            .Property(t => t.DateTimeEnd)
            .HasColumnType("timestamp without time zone");
    }

    
}
