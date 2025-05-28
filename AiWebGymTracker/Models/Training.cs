using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AiWebGymTracker.Models
{
    public class Training
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public ApplicationUser? Coach { get; set; }
        public ApplicationUser Trainee { get; set; }

        [Column("start_session")]
        public DateTime StartSession { get; set; }

        [Column("end_session")]
        public DateTime EndSession { get; set; }

        [Column("status")]
        public TrainingType  SessionType { get; set; }
    }
}
