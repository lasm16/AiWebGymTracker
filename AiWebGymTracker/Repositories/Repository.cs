using System;
using AiWebGymTracker.Models.Entities;
using AiWebGymTracker.Repositories.Abstractions;

namespace AiWebGymTracker.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    void IRepository<TEntity>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    TEntity IRepository<TEntity>.Get(int id)
    {
        throw new NotImplementedException();
    }

    IQueryable<TEntity> IRepository<TEntity>.GetAll()
    {
        throw new NotImplementedException();
    }

    void IRepository<TEntity>.Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    void IRepository<TEntity>.Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
