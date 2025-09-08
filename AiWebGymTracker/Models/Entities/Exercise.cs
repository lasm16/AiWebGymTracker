using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AiWebGymTracker.Models.Abstractions;
using AiWebGymTracker.Models.Enums;

namespace AiWebGymTracker.Models.Entities;

public class Exercise : Entity
{
    [Required]
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }

    public virtual List<ExerciseTraining> ExerciseTrainings { get; set; } = new List<ExerciseTraining>();
}
