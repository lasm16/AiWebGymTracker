using AiWebGymTracker.DAL;
using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.Models.Seeding
{
    public static class DataSeederExercise
    {

        public static async Task SeedDevelopmentData(AppDbContext context)
        {
            // Проверяем, есть ли уже данные
            if (!await context.Exercises.AnyAsync())
            {
                await SeedExercises(context);
                await SeedTrainings(context);
                await SeedExerciseTrainings(context);
                
                Console.WriteLine("Database seeded successfully!");
            }
            else
            {
                Console.WriteLine("Database already has data.");
            }
        }

        private static async Task SeedExercises(AppDbContext context)
        {
            var exercises = new List<Exercise>
            {
                new() { Name = "Приседания со штангой", Description = "Базовое упражнение для развития мышц ног и ягодиц" },
                new() { Name = "Жим лежа", Description = "Упражнение для развития грудных мышц, трицепсов и передних дельт" },
                new() { Name = "Становая тяга", Description = "Комплексное упражнение для развития спины, ног и ягодиц" },
                new() { Name = "Подтягивания", Description = "Упражнение для развития мышц спины и бицепсов" },
                new() { Name = "Отжимания на брусьях", Description = "Упражнение для развития грудных мышц и трицепсов" },
                new() { Name = "Жим штанги стоя", Description = "Упражнение для развития плечевого пояса" },
                new() { Name = "Тяга штанги в наклоне", Description = "Упражнение для развития мышц спины" },
                new() { Name = "Выпады с гантелями", Description = "Упражнение для развития ног и ягодиц" },
                new() { Name = "Планка", Description = "Упражнение для укрепления корпуса" },
                new() { Name = "Бег на беговой дорожке", Description = "Кардио упражнение для развития выносливости" }
            };

            await context.Exercises.AddRangeAsync(exercises);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTrainings(AppDbContext context)
        {
            var training = new Training
            {              
                
                DateTimeStart = DateTime.Now.AddDays(-1),
                DateTimeEnd = DateTime.Now.AddDays(-1).AddHours(1),
                TrainingType = TrainingType.Completed
            };

            await context.Trainings.AddAsync(training);
            await context.SaveChangesAsync();
        }

        private static async Task SeedExerciseTrainings(AppDbContext context)
{
    // Получаем первую созданную тренировку
    var training = await context.Trainings.FirstOrDefaultAsync();
    
    if (training == null)
    {
        Console.WriteLine("No training found! Creating one...");
        await SeedTrainings(context);
        training = await context.Trainings.FirstOrDefaultAsync();
    }

    var exerciseTrainings = new List<ExerciseTraining>
    {
        new()
        {
            ExerciseId = 1,
            TrainingId = training.Id, // Используем реальный ID тренировки
            Type = ExerciseType.Strength,
            Repetitions = 12,
            RangeRepetitions = 3,
            Duration = TimeSpan.FromMinutes(2),
            Weight = 50
        },
        new()
        {
            ExerciseId = 2,
            TrainingId = training.Id, // Используем реальный ID тренировки
            Type = ExerciseType.Strength,
            Repetitions = 10,
            RangeRepetitions = 4,
            Duration = TimeSpan.FromMinutes(3),
            Weight = 40
        },
        new()
        {
            ExerciseId = 10,
            TrainingId = training.Id, // Используем реальный ID тренировки
            Type = ExerciseType.Cardio,
            Repetitions = 0,
            RangeRepetitions = 0,
            Duration = TimeSpan.FromMinutes(20),
            Weight = 0
        }
    };

            await context.ExerciseTrainings.AddRangeAsync(exerciseTrainings);
            await context.SaveChangesAsync();
        }
    }
}
