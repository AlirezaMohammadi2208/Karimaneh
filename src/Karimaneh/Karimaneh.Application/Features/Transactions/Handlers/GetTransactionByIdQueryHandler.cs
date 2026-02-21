using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Application.Features.Transactions.Queries;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class GetTransactionByIdQueryHandler : IBaseQueryHandler<GetTransactionByIdQuery, TransactionResponseDto>
    {
        public Task<TransactionResponseDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
