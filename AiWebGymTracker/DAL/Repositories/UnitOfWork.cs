using System;
using AiWebGymTracker.DAL.Repositories.Abstractions;

namespace AiWebGymTracker.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IFoodRepository _foodRepository;
    private AppDbContext _appdDbContext;
    public IFoodRepository FoodRepository => _foodRepository;
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appdDbContext = appDbContext;
        _foodRepository = new FoodRepository(_appdDbContext);
    }
    public Task SavedChanged()
    {
        throw new NotImplementedException();
    }
}
