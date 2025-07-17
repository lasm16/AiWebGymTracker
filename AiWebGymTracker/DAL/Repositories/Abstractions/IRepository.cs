using System;

namespace AiWebGymTracker.DAL.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(int id);
    Task InsertAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity id);
}
