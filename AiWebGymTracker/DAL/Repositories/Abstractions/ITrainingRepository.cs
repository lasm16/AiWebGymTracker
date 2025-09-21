using AiWebGymTracker.DAL.Repositories.Abstractions;
using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.DAL
{
    public interface ITrainingRepository
    {
        Task<List<Training>> GetAllAsync();
        Task<Training> GetByIdAsync(int id);
        Task AddAsync(Training training);
        Task UpdateAsync(Training training);
    }
}
