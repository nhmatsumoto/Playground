using Microsoft.EntityFrameworkCore;
using Playground.Domain.Entities;
using Playground.Domain.Interfaces.Repository;
using Playground.Infrastructure.Database.Context;
using System.Linq.Expressions;

namespace Playground.Infrastructure.Database.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task Post(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Put(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<IEnumerable<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        protected async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
