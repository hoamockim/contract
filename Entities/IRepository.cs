
using System.Linq.Expressions;

namespace Entities {
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Entries();
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        int Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        int Delete(TEntity entity);
        int DeleteRange(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int UpdateRange(IEnumerable<TEntity> entities);
    }

    public interface IRepositoryAsync<TEntity> where TEntity : Entity
    {
        Task<int> AddAsync(TEntity entity);
    }
}