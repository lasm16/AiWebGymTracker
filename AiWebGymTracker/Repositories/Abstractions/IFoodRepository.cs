using System;
using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.Repositories.Abstractions;

public interface IFoodRepository : IRepository<Food>
{
    Task<IQueryable<Food>> GetAllFoodsAsync();
    Task<Food> GetFoodIdAsync(int id);
}
