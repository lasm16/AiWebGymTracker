using System;
using AiWebGymTracker.DAL.Repositories.Abstractions;

namespace AiWebGymTracker.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _appDbContext;
    private IFoodRepository _foodRepository;
    private ITrainingRepository _trainingRepository;

    public IFoodRepository FoodRepository => _foodRepository;
    public ITrainingRepository TrainingRepository => _trainingRepository;
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _foodRepository = new FoodRepository(_appDbContext);
        _trainingRepository = new TrainingsRepository(_appDbContext);
    }
    public Task SavedChangedAsync()
    {
        return  _appDbContext.SaveChangesAsync();
    }
}
