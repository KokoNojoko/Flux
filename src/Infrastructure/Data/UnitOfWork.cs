using System.Collections.Concurrent;
using Flux.Infrastructure.Persistence;
using Flux.Infrastucture.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore.Storage;

namespace Flux.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FluxDbContext _context;
        private bool _disposed;
        private IDbContextTransaction? _currentTransaction;

        private readonly ConcurrentDictionary<Type, object> _repositories = new();

        public UnitOfWork(FluxDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>()
            where T : class
        {
            return (IRepository<T>)
                _repositories.GetOrAdd(typeof(T), t => new Repository<T>(_context));
        }

        public int SaveChanges() => _context.SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _context.SaveChangesAsync(cancellationToken);

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null)
                return;

            _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
                return;

            await _currentTransaction.CommitAsync(cancellationToken);
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
                return;

            await _currentTransaction.RollbackAsync(cancellationToken);
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _currentTransaction?.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                await _context.DisposeAsync();
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                }
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
