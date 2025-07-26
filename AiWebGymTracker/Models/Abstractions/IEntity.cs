using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Abstractions
{
    public interface IEntity
    {
        [Key]
        [Column("column")]
        int Id { get; set; }
    }
}