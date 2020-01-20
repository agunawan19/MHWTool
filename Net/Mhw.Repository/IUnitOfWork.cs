using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Mhw.DataAccess;

namespace Mhw.Repository
{
    public interface IUnitOfWork<out TContext> : IDisposable where TContext : DbContext, new()
    {
        TContext Context { get; }

        void CreateTransaction();

        void Rollback();

        int Save();

        void Commit();
    }
}