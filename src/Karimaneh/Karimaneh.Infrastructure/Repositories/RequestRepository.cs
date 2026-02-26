using Common.Domain.Constract;
using Karimaneh.Domain.RequestAgg;
using Karimaneh.Domain.RequestAgg.Repository;
using Karimaneh.Infrastructure.Persistence;
using Karimaneh.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Karimaneh.Infrastructure.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly KarimanehDbContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public RequestRepository(KarimanehDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Request request, CancellationToken cancellationToken)
        {
            await _context.Requests.AddAsync(request);
        }

        public async Task<Request?> GetRequestById(Guid requestId)
        {
            return await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId);
        }
        public async Task<IEnumerable<Request>> GetAllAsync(ISpecification<Request> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Requests.AsQueryable();
            queryable = SpecificationEvaluator<Request>.GetQuery(queryable, spec);
            return await queryable.ToListAsync(cancellationToken);
        }
    }
}
