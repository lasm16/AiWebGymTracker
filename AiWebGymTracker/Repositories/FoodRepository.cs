using System;
using AiWebGymTracker.Repositories.Abstractions;
using Microsoft.AspNetCore.DataProtection.Repositories;
using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.Repositories;

public class FoodRepository : Repository<Food>, IFoodRepository
{
    Task<IQueryable<Food>> IFoodRepository.GetAllFoodsAsync()
    {
        throw new NotImplementedException();
    }

    Task<Food> IFoodRepository.GetFoodIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
