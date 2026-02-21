using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Application.Features.Transactions.Queries;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class GetAllTransactionsQueryHandler : IBaseQueryHandler<GetAllTransactionsQuery, IEnumerable<TransactionResponseDto>>
    {
        public Task<IEnumerable<TransactionResponseDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
