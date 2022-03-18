using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Entities { 
    public static class DataContextExtension {
        public static EntityEntry<TEntity> PropertyToPatch<TEntity, TProperty>(this EntityEntry<TEntity> entry, Expression<Func<TEntity, TProperty>>expression)
        where TEntity: Entity 
        {
            entry.Property(expression).IsModified = true;
            return entry;
        }

        public static void Patch<TEntity>(this EntityEntry<TEntity> entry)
        where TEntity: Entity
        {
            entry.Context.SaveChanges();
        }
    }
}