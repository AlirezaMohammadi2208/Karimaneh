using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Loans.DTOs;

namespace Karimaneh.Application.Features.Loans.Queries
{
    public class GetAllLoansQuery : IBaseQuery<IEnumerable<LoanResponseDto>>
    {
    }
}
