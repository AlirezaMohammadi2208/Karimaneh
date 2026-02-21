using AutoMapper;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Application.Features.Transactions.Queries;
using LoanManagementSystem.Application.Features.Transactions.Specifications;
using LoanManagementSystem.Application.Interfaces;
using LoanManagementSystem.Domain.Aggregates.TransactionAggregate;

namespace LoanManagementSystem.Application.Features.Transactions.Handlers
{
    public class GetTransactionByIdQueryHandler : IQueryHandler<GetTransactionByIdQuery, TransactionResponseDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<TransactionResponseDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new TransactionGetAllSpec();
            var transaction = await _transactionRepository.GetByIdAsync(request.Id, spec, cancellationToken);
            return _mapper.Map<TransactionResponseDto>(transaction);
        }
    }
}
