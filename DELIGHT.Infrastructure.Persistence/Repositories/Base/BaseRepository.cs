using DELIGHT.Core.Domain.Repository;
using DELIGHT.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DELIGHT.Infraestructure.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DELIGHTContext _context;
        public BaseRepository(DELIGHTContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _context.Set<T>().ToListAsync(cancellationToken);
            return entities;
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task<int> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
