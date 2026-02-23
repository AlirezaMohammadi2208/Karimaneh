using Common.Application.CQRS.Query;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Application.Features.Transactions.Queries;
using Karimaneh.Application.Features.Transactions.Specifications;
using Karimaneh.Application.Features.Wallets.Specifications;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Domain.TransactionAgg.Repository;
using Karimaneh.Domain.WalletAgg;
using Karimaneh.Domain.WalletAgg.Repository;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class GetAllTransactionsQueryHandler : IBaseQueryHandler<GetAllTransactionsQuery, IEnumerable<TransactionResponseDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IMemberRepository _memberRepository;

        public GetAllTransactionsQueryHandler(
            ITransactionRepository transactionRepository,
            IWalletRepository walletRepository,
            IMemberRepository memberRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<TransactionResponseDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var spec = new TransactionGetAllSpec();
            var transactions = await _transactionRepository.GetAllAsync(spec, cancellationToken);

            var result = await Task.WhenAll(transactions.Select(async x =>
            {
                var debitWallet = await _walletRepository.GetByIdAsync(x.DebitWalletId, new WalletGetAllSpec(), cancellationToken)
                ?? throw new NotFoundException("Wallet not found!");

                PayerDto payer = null!;
                if (debitWallet.WalletType == WalletType.Member)
                {
                    var member = await _memberRepository.GetByWalletIdAsync(x.DebitWalletId, cancellationToken)
                    ?? throw new NotFoundException("Member not found!");

                    payer = new PayerDto
                    {
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        PhoneNumber = "" //TODO: Fix This
                    };
                }
                else
                {
                    payer = new PayerDto
                    {
                        FirstName = "Fund",
                        LastName = "Fund",
                        PhoneNumber = "Fund"
                    };
                }

                return new TransactionResponseDto
                {
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    Id = x.Id,
                    Document = x.Document,
                    Status = x.TransactionStatus,
                    Type = x.TransactionType,
                    AmountPayable = debitWallet.Balance, //TODO: Add This Business
                    Payer = payer
                };
            }));
            return result;
        }
    }
}
