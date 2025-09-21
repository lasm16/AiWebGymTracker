using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.Infrastructure.Abstractions
{
    public interface ITrainingService
    {
        Task<List<Training>> GetAllTrainingsAsync();
        Task<Training> GetTrainingByIdAsync(int id);
        Task CreateTrainingAsync(Training training);
        Task CancelTrainingAsync(int id);
        Task UpdateExercisesAsync(int id, List<Exercise> exercises);
        Task UpdateTrainingDateAsync(int id, DateTime dateTimeStart);
        Task CompleteTrainingAsync(int id);
    }
}
