using Common.Domain.Constract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.TransactionAgg.Repository
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<Transaction?> GetByIdAsync(Guid id, ISpecification<Transaction> spec, CancellationToken cancellationToken = default);
        Task<IEnumerable<Transaction>> GetAllAsync(ISpecification<Transaction> spec, CancellationToken cancellationToken = default);
        Task<Transaction> AddAsync(Transaction transaction, CancellationToken cancellationToken = default);

    }
}
