using System;

namespace AiWebGymTracker.DAL.Repositories.Abstractions;

public interface IUnitOfWork
{
    IFoodRepository FoodRepository { get; }
    ITrainingRepository TrainingRepository { get; }
    Task SavedChangedAsync();
}
