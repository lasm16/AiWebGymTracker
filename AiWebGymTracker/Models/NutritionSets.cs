using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models
{
    public class NutritionSets
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nutrition_id")]
        public int NutritionId { get; set; }

        public Nutrition Nutrition { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        //public User User { get; set; }

        [Column("nutrition_type")]
        public NutritionType NutritionType { get; set; }
    }
}
