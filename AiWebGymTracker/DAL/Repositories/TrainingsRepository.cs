using AiWebGymTracker.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.DAL.Repositories
{
    public class TrainingsRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingsRepository(AppDbContext dbContext) : base(dbContext)
        { }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            return await AppDbContext.Trainings.ToListAsync();
        }

        public async Task<Training> GetTrainingByIdAsync(int id)
        {
            return await AppDbContext.Trainings.FindAsync(id);
        }       
    
    }
}
