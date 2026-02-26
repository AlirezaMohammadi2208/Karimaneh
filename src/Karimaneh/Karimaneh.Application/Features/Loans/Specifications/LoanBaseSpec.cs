using Karimaneh.Application.Specifications;
using Karimaneh.Domain.LoanAgg;

namespace Karimaneh.Application.Features.Loans.Specifications
{
    public abstract class LoanBaseSpec : Specification<Loan>
    {
        protected LoanBaseSpec()
        {
            AddInclude(x => x.Instalments);
        }
    }
}
