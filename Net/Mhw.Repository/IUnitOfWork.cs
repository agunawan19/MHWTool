using System;
using System.Threading.Tasks;

namespace Mhw.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();
    }
}