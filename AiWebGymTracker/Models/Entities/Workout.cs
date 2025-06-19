using System;
using System.ComponentModel.DataAnnotations;

namespace AiWebGymTracker.Models.Entities;

public class Workout : Entity
{
    [Required]
    public string Title { get; set; }
    public string Notes { get; set; }
    public TimeSpan Duration { get; set; }
    public int TotalCaloriesBurned { get; set; }
    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
