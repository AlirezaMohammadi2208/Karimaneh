using Common.Domain.Constract;
using Karimaneh.Domain.RequestAgg;
using Karimaneh.Domain.RequestAgg.Repository;
using Karimaneh.Infrastructure.Persistence;

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
    }
}
