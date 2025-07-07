using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AiWebGymTracker.Models.Enums;

namespace AiWebGymTracker.Models.Entities;

public class Exercise : Entity
{
    [Required]
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
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
    [ForeignKey("Training_Id")]
    [Column("training")]
    public Training? Training { get; set; }

}
