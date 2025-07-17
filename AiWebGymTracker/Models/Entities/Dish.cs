using AiWebGymTracker.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class Dish : Entity
    {
        public List<Food> Food { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("weight")]
        public int Weight { get; set; }
    }
}
