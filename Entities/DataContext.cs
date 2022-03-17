
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Entities {
    public class DataContext: DbContext {
        private readonly string _connection;

        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DataContext(string connection):base()
        {
            _connection = connection;
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseNpgsql(_connection);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!DomainRegister.Instance.IsModelCreated)
            {
                foreach (var registermodel in DomainRegister.Instance.RegisterModels)
                    registermodel.Invoke(modelBuilder);
                DomainRegister.Instance.IsModelCreated = true;
            }
        }

        public IQueryable<TEntity> Entries<TEntity>() where TEntity : Entity
        {
            return Set<TEntity>();
        }

        public IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity
        {
            return Set<TEntity>().Where(predicate);
        }

        public int Insert<TEntity>(TEntity entity) where TEntity : Entity
        {
            Attach(entity);
            Entry(entity).State = EntityState.Added;
            return SaveChanges();
        }

        public int AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            foreach (var entity in entities)
            {
                Attach(entity);
                Entry(entity).State = EntityState.Added;
            }
            return SaveChanges();
        }

        public int Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            Attach(entity);
            Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            foreach (var entity in entities)
            {
                Attach(entity);
                Entry(entity).State = EntityState.Deleted;
            }
            return SaveChanges();
        }

        public int Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            Attach(entity);
            Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public int UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            foreach (var entity in entities)
            {
                Attach(entity);
                Entry(entity).State = EntityState.Modified;
            }
            return SaveChanges();
        }
    }
}