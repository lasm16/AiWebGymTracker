using AiWebGymTracker.Models.Abstractions;
using AiWebGymTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiWebGymTracker.Models.Entities
{
    public class ExerciseTraining : Entity
    {
        [Column("exercise_id")]
        public int ExerciseId { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise? Exercise { get; set; }

        [Column("type")]
        public ExerciseType Type { get; set; }

        [Range(0, int.MaxValue)]
        [Column("repetitions")]
        public int Repetitions { get; set; }

        [Range(0, int.MaxValue)]
        [Column("range_repetitions")]
        public int RangeRepetitions { get; set; }

        [Column("duration")]
        public TimeSpan Duration { get; set; }

        [Required]
        [Column("weight")]
        public double Weight { get; set; }

        [Column("training_id")]
        public int TrainingId { get; set; }

        [ForeignKey("TrainingId")]
        public Training? Training { get; set; }
    }
}
