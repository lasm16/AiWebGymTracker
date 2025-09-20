using AiWebGymTracker.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class Dish : Entity
    {
        [Column("name")]
        public string? Name { get; set; }
        [Column("weight")]
        public int Weight { get; set; }
        [Column("food_id")]
        public List<Food> Foods { get; set; } = [];
    }
}
