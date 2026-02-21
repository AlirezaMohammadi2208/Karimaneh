using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Transactions.DTOs;

namespace Karimaneh.Application.Features.Transactions.Queries
{
    public class GetTransactionByIdQuery : IBaseQuery<TransactionResponseDto>
    {
        public Guid Id { get; set; }
    }
}
