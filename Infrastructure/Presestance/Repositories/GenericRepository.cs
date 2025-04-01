using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges)=>
           trackChanges? await _storeContext.Set<TEntity>().ToListAsync()
            : await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync() ;

        public async Task<TEntity?> GetByIdAsync(TKey id) => await _storeContext.Set<TEntity>().FindAsync(id);

        public async Task AddAsync(TEntity entity) => await _storeContext.Set<TEntity>().AddAsync(entity);

        public void UpdateAsync(TEntity entity)=>  _storeContext.Set<TEntity>().Update(entity);

        public void DeleteAsync(TEntity entity)=>  _storeContext.Set<TEntity>().Remove(entity);

    }
}
