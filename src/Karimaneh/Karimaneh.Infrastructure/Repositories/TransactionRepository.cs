using Common.Domain.Constract;
using Karimaneh.Domain.TransactionAgg;
using Karimaneh.Domain.TransactionAgg.Repository;
using Karimaneh.Infrastructure.Persistence;
using Karimaneh.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Karimaneh.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly KarimanehDbContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public TransactionRepository(KarimanehDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            return (await _context.Transactions.AddAsync(transaction, cancellationToken)).Entity;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(ISpecification<Transaction> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Transactions.AsQueryable();
            queryable = SpecificationEvaluator<Transaction>.GetQuery(queryable, spec);
            return await queryable.ToListAsync(cancellationToken);
        }

        public async Task<Transaction?> GetByIdAsync(Guid id, ISpecification<Transaction> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Transactions.AsQueryable();
            queryable = SpecificationEvaluator<Transaction>.GetQuery(queryable, spec);
            return await queryable.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
    }
}
