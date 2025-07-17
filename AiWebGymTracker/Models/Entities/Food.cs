using AiWebGymTracker.Models.Abstractions;
using AiWebGymTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class Food : Entity
    {
        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        [Column("calories")]
        public double Calories { get; set; }
        [Range(0, double.MaxValue)]
        [Column("protein")]
        public double Protein { get; set; }
        [Range(0, double.MaxValue)]
        [Column("fat")]
        public double Fat { get; set; }
        [Range(0, double.MaxValue)]
        [Column("carbohydrates")]
        public double Carbohydrates { get; set; }
        [Required]
        [Column("food_category")]
        public FoodCategory FoodCategory { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Column("image_url")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}