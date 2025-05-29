using System.ComponentModel.DataAnnotations;

namespace AiWebGymTracker.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public double Calories { get; set; }
        [Range(0, double.MaxValue)]
        public double Protein { get; set; }
        [Range(0, double.MaxValue)]
        public double Fat { get; set; }
        [Range(0, double.MaxValue)]
        public double Carbohydrates { get; set; }
        [Required]
        [Column("food_category")]
        public FoodCategory FoodCategory { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; } = string.Empty;
    }
}