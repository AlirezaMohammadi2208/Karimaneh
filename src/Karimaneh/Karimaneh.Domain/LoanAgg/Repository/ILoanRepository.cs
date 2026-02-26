using Common.Domain.Constract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.LoanAgg.Repository
{
    public interface ILoanRepository : IBaseRepository<Loan>
    {
        //TODO: Check This for clear useless method
        Task<Loan> AddAsync(Loan loan, CancellationToken cancellationToken = default);
        Loan Update(Loan loan);
        Task<Loan?> GetByIdAsync(Guid id, ISpecification<Loan> spec, CancellationToken cancellationToken = default);
        Task<IEnumerable<Loan>> GetAllAsync(ISpecification<Loan> spec, CancellationToken cancellationToken = default);
    }
}
