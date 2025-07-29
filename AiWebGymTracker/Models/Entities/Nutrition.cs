using AiWebGymTracker.Models.Abstractions;
using AiWebGymTracker.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class Nutrition : Entity
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("dish_id")]
        public int DishId { get; set; }

        [Column("nutrition_type")]
        public NutritionType NutritionType { get; set; }
    }
}
