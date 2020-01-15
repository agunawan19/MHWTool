using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MhwDataAccess;
using MHWEntity;

namespace MhwRepository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MHWContext _context;

        public UnitOfWork(MHWContext context) =>
            _context = context;

        public int Commit() =>
            _context.SaveChanges();

        public async Task<int> CommitAsync() =>
            await _context.SaveChangesAsync().ConfigureAwait(false);

        public void Dispose() =>
            _context.Dispose();
    }
}