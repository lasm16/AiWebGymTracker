using System;

namespace AiWebGymTracker.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    TEntity Get(int id);
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
}
