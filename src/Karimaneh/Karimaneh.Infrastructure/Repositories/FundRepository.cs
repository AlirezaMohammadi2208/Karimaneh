using Common.Domain.Constract;
using Karimaneh.Domain.FundAgg;
using Karimaneh.Domain.FundAgg.Repository;
using Karimaneh.Infrastructure.Persistence;
using Karimaneh.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Karimaneh.Infrastructure.Repositories
{
    public class FundRepository : IFundRepository
    {
        private readonly KarimanehDbContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public FundRepository(KarimanehDbContext context)
        {
            _context = context;
        }
        public async Task<Fund> AddAsync(Fund fund, CancellationToken cancellationToken = default)
        {
            return (await _context.Funds.AddAsync(fund, cancellationToken)).Entity;
        }

        public async Task<IEnumerable<Fund>> GetAllAsync(ISpecification<Fund> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Funds.AsQueryable();
            queryable = SpecificationEvaluator<Fund>.GetQuery(queryable, spec);
            return await queryable.ToListAsync(cancellationToken);
        }

        public async Task<Fund?> GetByIdAsync(Guid id, ISpecification<Fund> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Funds.AsQueryable();
            queryable = SpecificationEvaluator<Fund>.GetQuery(queryable, spec);
            return await queryable.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public Fund Update(Fund fund)
        {
            return _context.Funds.Update(fund).Entity;
        }
    }
}
