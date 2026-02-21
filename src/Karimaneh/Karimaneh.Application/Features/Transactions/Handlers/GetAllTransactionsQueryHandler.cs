using AutoMapper;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Application.Features.Transactions.Queries;
using LoanManagementSystem.Application.Features.Transactions.Specifications;
using LoanManagementSystem.Application.Interfaces;
using LoanManagementSystem.Domain.Aggregates.TransactionAggregate;

namespace LoanManagementSystem.Application.Features.Transactions.Handlers
{
    public class GetAllTransactionsQueryHandler : IQueryHandler<GetAllTransactionsQuery, IEnumerable<TransactionResponseDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionResponseDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var spec = new TransactionGetAllSpec();
            var transactions = await _transactionRepository.GetAllAsync(spec, cancellationToken);

            return transactions.Select(x =>
            {
                return new TransactionResponseDto
                {
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    Id = x.Id,
                    Document = x.Document,
                    Status = x.Status,
                    Type = x.Type,
                    AmountPayable = x.DebitWalletAccount.Balance, //TODO: Add This Business
                    Payer = x.DebitWalletAccount.Member is not null ?
                    new PayerDto
                    {
                        FirstName = x.DebitWalletAccount.Member.FirstName,
                        LastName = x.DebitWalletAccount.Member.LastName,
                        PhoneNumber = x.DebitWalletAccount.Member.PhoneNumber
                    }
                    : new PayerDto
                    {
                        FirstName = "Fund",
                        LastName = "Fund",
                        PhoneNumber = "Fund"
                    }
                };
            });
        }
    }
}
