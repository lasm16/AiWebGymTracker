using AiWebGymTracker.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class Nutrition : Entity
    {
        public List<Dish> Dishes { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Column("nutrition_type")]
        public NutritionType NutritionType { get; set; }
    }
}
