using System;
using System.ComponentModel.DataAnnotations;
using AiWebGymTracker.Models.Enums;

namespace AiWebGymTracker.Models.Entities;

public class Exercise : Entity
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public ExerciseType Type { get; set; }
    public int Repetitions { get; set; }
    public int RangeRepetitions { get; set; }
    public TimeSpan Duration { get; set; }
    [Required]
    public double Weight { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }

}
