using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.DAL.Repositories.Abstractions
{
    public interface ITrainingRepository : IRepository<Training>
    {
        Task<List<Training>> GetAllTrainingsAsync();
        Task<Training> GetTrainingByIdAsync(int id);

    }
}
