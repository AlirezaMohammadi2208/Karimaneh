using Common.Domain.Constract;
using Karimaneh.Domain.LoanAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.FundAgg.Repository
{
    public interface IFundRepository : IBaseRepository<Fund>
    {
        Task<Fund> AddAsync(Fund fund, CancellationToken cancellationToken = default);
        Task<Fund?> GetByIdAsync(Guid id, ISpecification<Fund> spec, CancellationToken cancellationToken = default);
        Task<IEnumerable<Fund>> GetAllAsync(ISpecification<Fund> spec, CancellationToken cancellationToken = default);
        Fund Update(Fund fund);
    }
}
