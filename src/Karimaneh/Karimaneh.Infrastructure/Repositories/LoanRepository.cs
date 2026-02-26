using Common.Domain.Constract;
using Karimaneh.Domain.LoanAgg;
using Karimaneh.Domain.LoanAgg.Repository;
using Karimaneh.Infrastructure.Persistence;
using Karimaneh.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Karimaneh.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly KarimanehDbContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public LoanRepository(KarimanehDbContext context)
        {
            _context = context;
        }
        public async Task<Loan> AddAsync(Loan loan, CancellationToken cancellationToken = default)
        {
            return (await _context.Loans.AddAsync(loan, cancellationToken)).Entity;
        }

        public Loan Update(Loan loan)
        {
            return _context.Loans.Update(loan).Entity;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync(ISpecification<Loan> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Loans.AsQueryable();
            queryable = SpecificationEvaluator<Loan>.GetQuery(queryable, spec);
            return await queryable.ToListAsync(cancellationToken);
        }

        public async Task<Loan?> GetByIdAsync(Guid id, ISpecification<Loan> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Loans.AsQueryable();
            queryable = SpecificationEvaluator<Loan>.GetQuery(queryable, spec);
            return await queryable.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
    }
}
