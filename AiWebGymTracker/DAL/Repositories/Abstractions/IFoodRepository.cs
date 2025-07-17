using System;
using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.DAL.Repositories.Abstractions;

public interface IFoodRepository : IRepository<Food>
{
    Task<List<Food>> GetAllFoodsAsync();
    Task<Food> GetFoodByIdAsync(int id);
}
