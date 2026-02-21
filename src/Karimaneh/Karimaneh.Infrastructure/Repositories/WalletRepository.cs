using Common.Domain.Constract;
using Karimaneh.Domain.WalletAgg;
using Karimaneh.Domain.WalletAgg.Repository;
using Karimaneh.Infrastructure.Persistence;
using Karimaneh.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Karimaneh.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly KarimanehDbContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public WalletRepository(KarimanehDbContext context)
        {
            _context = context;
        }
        public async Task<Wallet> AddAsync(Wallet wallet, CancellationToken cancellationToken = default)
        {
            return (await _context.Wallets.AddAsync(wallet, cancellationToken)).Entity;
        }

        public async Task<IEnumerable<Wallet>> GetAllAsync(ISpecification<Wallet> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Wallets.AsQueryable();
            queryable = SpecificationEvaluator<Wallet>.GetQuery(queryable, spec);
            return await queryable.ToListAsync(cancellationToken);
        }

        public async Task<Wallet?> GetByIdAsync(Guid id, ISpecification<Wallet> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Wallets.AsQueryable();
            queryable = SpecificationEvaluator<Wallet>.GetQuery(queryable, spec);
            return await queryable.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
    }
}
