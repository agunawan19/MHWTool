using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Mhw.DataAccess;

namespace Mhw.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private IDbSet<TEntity> _entities;
        private bool _isDisposed;

        public GenericRepository(IUnitOfWork<MhwContext> unitOfWork) : this(unitOfWork.Context)
        {
        }

        public GenericRepository(MhwContext context) => Context = context;

        public MhwContext Context { get; set; }

        public virtual IQueryable<TEntity> Table => Entities;

        protected virtual IDbSet<TEntity> Entities =>
            _entities ?? (_entities = Context.Set<TEntity>());

        private IQueryable<TEntity> EntitiesAsNoTracking => Entities.AsNoTracking();

        public void Dispose()
        {
            Context?.Dispose();
            _isDisposed = true;
        }

        public virtual IEnumerable<TEntity> GetAll(bool trackChanges = true) =>
            trackChanges ? Entities.ToList() : EntitiesAsNoTracking.ToList();

        public virtual TEntity GetById(object id) => Entities.Find(id);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool trackChanges = true) =>
            trackChanges ? Entities.Where(predicate) : EntitiesAsNoTracking.Where(predicate);

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, bool trackChanges = true) =>
            trackChanges ? Entities.SingleOrDefault(predicate) : EntitiesAsNoTracking.SingleOrDefault(predicate);

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool trackChanges = true) =>
            trackChanges ? Entities.FirstOrDefault(predicate) : EntitiesAsNoTracking.FirstOrDefault(predicate);

        public virtual void InsertOrUpdate(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    if (Context == null || _isDisposed)
                    {
                        Context = new MhwContext();
                    }

                    Context.Set<TEntity>().AddOrUpdate(entity);
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        public void InsertOrUpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities != null)
                {
                    foreach (var entity in entities)
                    {
                        InsertOrUpdate(entity);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(entities));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    if (Context == null || _isDisposed)
                    {
                        Context = new MhwContext();
                    }

                    Entities.Add(entity);
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities != null)
                {
                    foreach (var entity in entities)
                    {
                        Insert(entity);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(entities));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    if (Context == null || _isDisposed)
                    {
                        Context = new MhwContext();
                    }

                    AttachEntity(entity);
                    SetEntryModified(entity);
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        private bool AttachEntity(TEntity entity)
        {
            var isDetached = Context.Entry(entity).State == EntityState.Detached;

            try
            {
                if (isDetached)
                {
                    var storeEntity = Context.Set<TEntity>().Find(GetPrimaryKeyValues(entity).ToArray());

                    if (storeEntity != null)
                    {
                        Context.Entry(storeEntity).State = EntityState.Detached;
                    }

                    Context.Set<TEntity>().Attach(entity);
                }
            }
            catch (Exception e)
            {
                ThrowException(e, e.Message);
            }

            return isDetached;
        }

        private IEnumerable<string> GetPrimaryKeyNames()
        {
            var objectContext = ((IObjectContextAdapter) Context).ObjectContext;
            var objectSet = objectContext.CreateObjectSet<TEntity>();
            var primaryKeyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(t => t.Name);

            return primaryKeyNames;
        }

        private IEnumerable<object> GetPrimaryKeyValues(TEntity entity)
        {
            var primaryKeyNames = new HashSet<string>(GetPrimaryKeyNames());
            var primaryKeyValues = entity.GetType()
                .GetProperties()
                .Where(propertyInfo => primaryKeyNames.Contains(propertyInfo.Name))
                .Select(propertyInfo => propertyInfo.GetValue(entity));

            return primaryKeyValues;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities != null)
                {
                    foreach (var entity in entities)
                    {
                        Update(entity);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(entities));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        protected virtual void SetEntryModified(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                ThrowException(e, e.Message);
            }
        }

        protected virtual void SetEntryDeleted(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                ThrowException(e, e.Message);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    if (Context == null || _isDisposed)
                    {
                        Context = new MhwContext();
                    }

                    AttachEntity(entity);
                    Entities.Remove(entity);
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities != null)
                {
                    foreach (var entity in entities)
                    {
                        Delete(entity);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(entities));
                }
            }
            catch (DbEntityValidationException exception)
            {
                ThrowException(exception, GetEntityValidationErrorMessage(exception));
            }
        }

        private void ThrowException(Exception exception, string errorMessage)
        {
            throw new Exception(errorMessage, exception);
        }

        private string GetEntityValidationErrorMessage(DbEntityValidationException exception)
        {
            var errorMessage = new StringBuilder();

            foreach (var validationErrors in exception.EntityValidationErrors)
            {
                GetValidationErrorMessage(validationErrors, errorMessage);
            }

            return errorMessage.ToString();
        }

        private void GetValidationErrorMessage(DbEntityValidationResult validationErrors, StringBuilder errorMessage)
        {
            foreach (var validationError in validationErrors.ValidationErrors)
            {
                errorMessage.Append($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")
                    .AppendLine();
            }
        }
    }
}