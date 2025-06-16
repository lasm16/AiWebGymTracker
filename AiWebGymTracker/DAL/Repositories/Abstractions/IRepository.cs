namespace AiWebGymTracker.DAL.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity id);

    }
}
