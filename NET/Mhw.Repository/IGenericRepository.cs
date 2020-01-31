using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mhw.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll(bool trackChanges = true);
        TEntity GetById(object id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool trackChanges = true);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, bool trackChanges = true);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool trackChanges = true);
        void InsertOrUpdate(TEntity entity);
        void InsertOrUpdateRange(IEnumerable<TEntity> entities);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}