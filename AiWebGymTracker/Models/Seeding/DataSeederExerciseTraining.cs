using AiWebGymTracker.DAL;
using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AiWebGymTracker.Models.Seeding
{
    public class DataSeederExerciseTraining
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new();

        public DataSeederExerciseTraining(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync(int count)
        {
            var exerciseTrainings = new List<ExerciseTraining>(count);
            var types = Enum.GetValues<ExerciseType>();           

            
            for (int i = 0; i < count; i++)
            {
                var type = types[_random.Next(types.Length)];
                
                var (repetitions, rangeRepetitions, weight, duration) = type switch
                {
                    ExerciseType.Strength => GenerateStrengthParams(),
                    ExerciseType.Cardio => GenerateCardioParams(),
                    ExerciseType.Flexibility => GenerateFlexibilityParams(),
                    ExerciseType.Balance => GenerateBalanceParams(),
                    _ => GenerateDefaultParams()
                };

                exerciseTrainings.Add(new ExerciseTraining
                {
                    Type = type,
                    Repetitions = repetitions,
                    RangeRepetitions = rangeRepetitions,
                    Weight = weight,
                    Duration = duration
                });
            }

            await _context.BulkInsertAsync(exerciseTrainings);
        }        

        private (int reps, int rangeReps, double weight, TimeSpan duration) GenerateStrengthParams()
        {
            return (
                reps: _random.Next(3, 8),
                rangeReps: _random.Next(0, 2) == 0 ? _random.Next(8, 12) : 0,
                weight: Math.Round(_random.NextDouble() * 80 + 20, 2),
                duration: TimeSpan.Zero
            );
        }

        private (int reps, int rangeReps, double weight, TimeSpan duration) GenerateCardioParams()
        {
            return (
                reps: 0,
                rangeReps: 0,
                weight: 0.0,
                duration: TimeSpan.FromMinutes(_random.Next(10, 60))
            );
        }

        private (int reps, int rangeReps, double weight, TimeSpan duration) GenerateFlexibilityParams()
        {
            return (
                reps: _random.Next(3, 6),
                rangeReps: _random.Next(0, 2) == 0 ? _random.Next(6, 10) : 0,
                weight: 0.0,
                duration: TimeSpan.FromSeconds(_random.Next(30, 90))
            );
        }

        private (int reps, int rangeReps, double weight, TimeSpan duration) GenerateBalanceParams()
        {
            return (
                reps: 1,
                rangeReps: 0,
                weight: 0.0,
                duration: TimeSpan.FromSeconds(_random.Next(20, 60))
            );
        }

        private (int reps, int rangeReps, double weight, TimeSpan duration) GenerateDefaultParams()
        {
            return (
                reps: 5,
                rangeReps: 0,
                weight: 50.0,
                duration: TimeSpan.Zero
            );
        }
    }
}

