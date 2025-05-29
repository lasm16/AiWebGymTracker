using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models
{
    public class Dish
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        //public Meal Meal { get; set; }
        [Column("weight")]
        public int Weight { get; set; }
    }
}
