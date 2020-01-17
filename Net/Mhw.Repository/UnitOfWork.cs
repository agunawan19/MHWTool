using System.Threading.Tasks;
using Mhw.DataAccess;

namespace Mhw.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MhwContext _context;

        public UnitOfWork(MhwContext context) =>
            _context = context;

        public int Commit() =>
            _context.SaveChanges();

        public async Task<int> CommitAsync() =>
            await _context.SaveChangesAsync().ConfigureAwait(false);

        public void Dispose() =>
            _context.Dispose();
    }
}