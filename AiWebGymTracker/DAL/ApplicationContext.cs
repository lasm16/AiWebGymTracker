using AiWebGymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<Meals> Meals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meals>().HasKey(m => m.MealId);
            modelBuilder.Entity<Meals>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(300)
                .HasDefaultValueSql("''");
            modelBuilder.Entity<Meals>()
            .Property(m => m.Description)
            .HasMaxLength(int.MaxValue)
            .IsRequired(false);

            modelBuilder.Entity<Meals>()
                .HasMany(m => m.Ingredients)
                .WithMany(i => i.Meals)
                .UsingEntity<Dictionary<string, object>>(
                    "MealIngredient",
                    j => j.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientId").HasConstraintName("FK_MealIngredient_Ingredient_IngredientId"),
                    j => j.HasOne<Meal>().WithMany().HasForeignKey("MealId").HasConstraintName("FK_MealIngredient_Meal_MealId"),
                    j =>
                    {
                        j.HasKey("MealId", "IngredientId");
                        j.ToTable("MealIngredient");
                    });
        }
    }
}
