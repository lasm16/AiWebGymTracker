using AiWebGymTracker.DAL.Repositories.Abstractions;
using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.DAL
{
    public interface ITrainingRepository : IRepository<Training>
    {
       Task<List<Training>> GetAllTrainingsAsync();
       Task<Training> GetTrainingByIdAsync(int id);       
    }
}
