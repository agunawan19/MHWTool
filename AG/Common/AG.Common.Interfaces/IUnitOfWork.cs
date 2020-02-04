using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG.Common.Interfaces
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