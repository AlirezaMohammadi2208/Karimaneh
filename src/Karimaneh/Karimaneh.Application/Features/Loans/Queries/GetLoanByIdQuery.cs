using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Loans.DTOs;

namespace Karimaneh.Application.Features.Loans.Queries
{
    public class GetLoanByIdQuery : IBaseQuery<LoanResponseDto>
    {
        public Guid Id { get; set; }
    }
}
