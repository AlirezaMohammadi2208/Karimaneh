using Karimaneh.Application.Features.Transactions.DTOs;

namespace Karimaneh.Application.Features.Transactions.Queries
{
    public class GetTransactionByIdQuery : IQuery<TransactionResponseDto>
    {
        public Guid Id { get; set; }
    }
}
