using System.Linq.Expressions;

namespace Entities {
    public class GenericRepository<TEntity> : IRepository<TEntity>, IRepositoryAsync<TEntity> where TEntity : Entities.Entity
    {
        private readonly DataContext _dataContext;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public DataContext DataContext {
            get
            {
                return _dataContext;
            }
        }

        public int Add(TEntity entity)
        {
            return  _dataContext.Insert(entity);
        }

        public Task<int> AddAsync(TEntity entity)
        {
            return Task.Run(() => Add(entity));
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
            return _dataContext.UpdateRange(entities);
        }

        public int Patch(TEntity entity, params string[] expressions){
            var entry = _dataContext.Attach(entity);
            foreach(var expression in expressions){
                entry.Property(expression).IsModified = true;
            }
            return _dataContext.SaveChanges();
        }
    }
}