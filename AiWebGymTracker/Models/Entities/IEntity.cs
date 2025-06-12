using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public interface IEntity
    {
        [Key]
        [Column("id")]
        int Id { get; set; }
    }
}