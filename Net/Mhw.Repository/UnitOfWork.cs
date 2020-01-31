using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;

namespace Mhw.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private bool _disposed;
        private readonly StringBuilder _errorMessage = new StringBuilder();
        private DbContextTransaction _transaction;
        private Dictionary<string, object> _repositories;

        public UnitOfWork()
        {
            Context = new TContext();
        }

        public TContext Context { get; }

        public void CreateTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            if (_transaction?.UnderlyingTransaction?.Connection == null) return;

            using (_transaction)
            {
                _transaction.Rollback();
            }
        }

        public int Save()
        {
            int returnValue;

            try
            {
                returnValue = Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage.AppendFormat("Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage)
                            .AppendLine();
                    }
                }

                throw new Exception(_errorMessage.ToString(), dbEx);
            }

            return returnValue;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) Context?.Dispose();

            _disposed = true;
        }

        public GenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (GenericRepository<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(GenericRepository<TEntity>);
            //var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), typeof(MhwContext));
            var repositoryInstance = Activator.CreateInstance(repositoryType, Context);
            _repositories.Add(type, repositoryInstance);

            return (GenericRepository<TEntity>)_repositories[type];
        }
    }
}