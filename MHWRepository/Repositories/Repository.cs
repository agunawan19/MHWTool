using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MhwRepository.Repositories
{
    public class Repository<TEntity> :
        IRepository<TEntity>, IRepositoryAsync<TEntity>
        where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            Context = context;
            _entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity) =>
            _entities.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) =>
            _entities.AddRange(entities);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
            _entities.Where(predicate);

        public TEntity Get(int id) =>
            _entities.Find(id);

        public IEnumerable<TEntity> GetAll() =>
            _entities.ToList();

        public void Remove(TEntity entity) =>
            _entities.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) =>
            _entities.RemoveRange(entities);

        public async Task<TEntity> GetAsync(int id) =>
            await _entities.FindAsync(id).ConfigureAwait(false);

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _entities.ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Task.FromResult(Find(predicate)).ConfigureAwait(false);

        public async Task AddAsync(TEntity entity) =>
            await Task.Run(() => Add(entity)).ConfigureAwait(false);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
            await Task.Run(() => AddRange(entities)).ConfigureAwait(false);

        public async Task RemoveAsync(TEntity entity) =>
            await Task.Run(() => Remove(entity)).ConfigureAwait(false);

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities) =>
            await Task.Run(() => RemoveRange(entities)).ConfigureAwait(false);
    }
}