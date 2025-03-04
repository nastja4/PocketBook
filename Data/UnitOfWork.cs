using System.Threading.Tasks;
using PocketBook.Core.IConfiguration;
using PocketBook.Core.IRepository;
using PocketBook.Core.Repositories;
using PocketBook.Models;

namespace PocketBook.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        // public async Task Dispose()
        // {
        //     await _context.DisposeAsync();
        // }
    }
}