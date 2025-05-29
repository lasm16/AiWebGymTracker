using AiWebGymTracker.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class Training : Entity
    {
        [Column("coach_id")]
        public int CoachId { get; set; }
        public ApplicationUser? Coach { get; set; }
        [Column("trainee_id")]
        public int TraineeId { get; set; }
        public ApplicationUser Trainee { get; set; }

        [Column("start_training")]
        public DateTime DateTimeStart { get; set; }

        [Column("end_training")]
        public DateTime DateTimeEnd { get; set; }

        [Column("status")]
        public TrainingType TrainingType { get; set; }
    }
}
