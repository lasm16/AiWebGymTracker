using System;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;

using AiWebGymTracker.DAL.Repositories.Abstractions;
using AiWebGymTracker.Models.Entities;

namespace AiWebGymTracker.DAL.Repositories;

public class FoodRepository : Repository<Food>, IFoodRepository
{
    public FoodRepository(AppDbContext dbContext) : base(dbContext)
    { }
    public async Task<List<Food>> GetAllFoodsAsync()
    {
        var query = AppDbContext.Foods.AsQueryable();
        return await query.ToListAsync();
    }
    public async Task<Food> GetFoodByIdAsync(int id)
    {
        return await AppDbContext.Foods.FindAsync(id);
    }
}
