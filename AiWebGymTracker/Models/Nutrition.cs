using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models
{
    public class Nutrition
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        //public Meal Meal { get; set; }
        [Column("count")]
        public int Count { get; set; }
    }
}
