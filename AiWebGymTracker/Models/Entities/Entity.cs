using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class Entity : IEntity
    {
        [Key]
        [Column("column")]
        public int Id { get; set; }
    }
}
