using AiWebGymTracker.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.DAL.Repositories
{
    public class TrainingsRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingsRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<Training>> GetAllAsync()
        {
            return await AppDbContext.Trainings
                .Include(t => t.Coach)
                .Include(t => t.Trainee)
                .Include(t => t.Exercises)
                .ToListAsync();
        }

        public async Task<Training> GetByIdAsync(int id)
        {
            return await AppDbContext.Trainings
                .Include(t => t.Coach)
                .Include(t => t.Trainee)
                .Include(t => t.Exercises)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Training training)
        {
            AppDbContext.Trainings.Add(training);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Training training)
        {
            AppDbContext.Trainings.Update(training);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
