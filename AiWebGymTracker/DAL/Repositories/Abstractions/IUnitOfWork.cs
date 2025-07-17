using System;

namespace AiWebGymTracker.DAL.Repositories.Abstractions;

public interface IUnitOfWork
{
    IFoodRepository FoodRepository { get; }
    Task SavedChanged();
}
