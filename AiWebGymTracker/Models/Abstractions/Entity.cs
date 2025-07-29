using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Abstractions
{
    public abstract class Entity : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
