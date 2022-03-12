using System.Linq.Expressions;

namespace Entities {
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entities.Entity
    {
        private readonly DataContext _dataContext;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Add(TEntity entity)
        {
            return  _dataContext.Insert(entity);
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            return _dataContext.AddRange(entities);
        }

        public int Delete(TEntity entity)
        {
            return _dataContext.Delete(entity);
        }

        public int DeleteRange(IEnumerable<TEntity> entities)
        {
            return _dataContext.DeleteRange(entities);
        }

        public IQueryable<TEntity> Entries()
        {
            return _dataContext.Entries<TEntity>();
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataContext.Filter(predicate);
        }

        public int Update(TEntity entity)
        {
             return _dataContext.Update(entity);
        }

        public int UpdateRange(IEnumerable<TEntity> entities)
        {
           throw new NotImplementedException();
        }
    }
}