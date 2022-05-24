using Playground.Domain.Entities;
using System.Linq.Expressions;

namespace Playground.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Post(TEntity entity);
        Task Delete(TEntity entity);
        Task Put(TEntity entity);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetByExpression(Expression<Func<TEntity, bool>> predicate);
        
    }
}
