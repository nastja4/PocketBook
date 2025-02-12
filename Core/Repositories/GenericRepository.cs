using Microsoft.EntityFrameworkCore;
using PocketBook.Core.IRepository;
using PocketBook.Data;

namespace PocketBook.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            // _context = context ?? throw new ArgumentNullException(nameof(context));
            // _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.dbSet = _context.Set<T>(); // Initialize dbSet
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            // return await dbSet.FindAsync(id);
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} was not found.");
            }
            return entity;
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

