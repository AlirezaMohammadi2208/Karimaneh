using Common.Domain.Constract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.RequestAgg.Repository
{
    public interface IRequestRepository : IBaseRepository<Request>
    {
        Task AddAsync(Request request, CancellationToken cancellationToken = default);
        Task<Request?> GetRequestById(Guid requestId);
        Task<IEnumerable<Request>> GetAllAsync(ISpecification<Request> spec, CancellationToken cancellationToken = default);
    }
}
