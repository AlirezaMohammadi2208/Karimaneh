using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Funds.DTOs;

namespace Karimaneh.Application.Features.Funds.Queries
{
    public class GetAllFundsQuery : IBaseQuery<IEnumerable<FundResponseDto>>
    {
    }
}
