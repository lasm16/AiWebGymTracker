using AiWebGymTracker.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AiWebGymTracker.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext AppDbContext;
        private readonly DbSet<TEntity> _entitySet;
        public Repository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            _entitySet = appDbContext.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return _entitySet.AsNoTracking();
        }
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
        public virtual TEntity Get(int id)
        {
            return _entitySet.Find(id);
        }
        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _entitySet.FindAsync(id);
        }
        public virtual void Insert(TEntity entity)
        {
            _entitySet.Add(entity);
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            await _entitySet.AddAsync(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _entitySet.Update(entity);
        }
        public virtual void Delete(TEntity id)
        {
            _entitySet.Remove(id);
        }            
    {
    }
}
