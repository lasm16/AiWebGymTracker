using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models
{
    public class Nutrition
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        public List<Dish> Dishes { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Column("nutrition_type")]
        public NutritionType NutritionType { get; set; }
    }
}
