using System;

namespace AiWebGymTracker.Models;

public class Meals
{
    public int MealId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public MealType MealType { get; set; }
    public double Calories { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public MealCategory MealCategory { get; set; }
    public int MealCategoryId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public MealCategory MealCategory { get; set; }
    public ICollection<MealPlan> MealPlans { get; set; }
    public ICollection<MealIngredient> Ingredients { get; set; }
    public ICollection<UserMeal> UserMeals { get; set; }
    public ICollection<MealRecipe> MealRecipes { get; set; }
    public ICollection<MealReview> MealReviews { get; set; }
    public ICollection<MealComment> MealComments { get; set; }
    public ICollection<MealRating> MealRatings { get; set; }
    public ICollection<MealOrder> MealOrders { get; set; }
    public ICollection<MealFavourite> MealFavourites { get; set; }

}
