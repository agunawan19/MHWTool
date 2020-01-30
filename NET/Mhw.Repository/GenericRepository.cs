using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public GenericRepository(IUnitOfWork<MhwContext> unitOfWork)
            : this(unitOfWork.Context)
        {
        }

        public GenericRepository(MhwContext context) => Context = context;

        public MhwContext Context { get; set; }

        public virtual IQueryable<TEntity> Table => Entities;

        protected virtual IDbSet<TEntity> Entities =>
            _entities ?? (_entities = Context.Set<TEntity>());

        public void Dispose()
        {
            Context?.Dispose();
            _isDisposed = true;
        }

        public virtual IEnumerable<TEntity> GetAll() => Entities.ToList();

        public virtual TEntity GetById(object id) => Entities.Find(id);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Entities.Where(predicate);

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => Entities.SingleOrDefault(predicate);

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => Entities.FirstOrDefault(predicate);

        public virtual void Insert(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    Entities.Add(entity);

                    if (Context == null || _isDisposed) Context = new MhwContext();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                ThrowException(dbEx, GetEntityValidationErrorMessage(dbEx));
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    if (Context == null || _isDisposed) Context = new MhwContext();
                    SetEntryModified(entity);
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                ThrowException(dbEx, GetEntityValidationErrorMessage(dbEx));
            }
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            try
            {
                if (entities != null)
                {
                    if (Context == null || _isDisposed) Context = new MhwContext();

                    foreach (var entity in entities)
                    {
                        SetEntryModified(entity);
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(entities));
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                ThrowException(dbEx, GetEntityValidationErrorMessage(dbEx));
            }
        }

        public virtual void SetEntryModified(TEntity entity) =>
            Context.Entry(entity).State = EntityState.Modified;

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    if (Context == null || _isDisposed) Context = new MhwContext();

                    Entities.Remove(entity);
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                ThrowException(dbEx, GetEntityValidationErrorMessage(dbEx));
            }
        }

        private void ThrowException(Exception dbEx, string errorMessage)
        {
            throw new Exception(errorMessage, dbEx);
        }

        private string GetEntityValidationErrorMessage(DbEntityValidationException dbEx)
        {
            var errorMessage = new StringBuilder();

            foreach (var validationErrors in dbEx.EntityValidationErrors) GetValidationErrorMessage(validationErrors, errorMessage);

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