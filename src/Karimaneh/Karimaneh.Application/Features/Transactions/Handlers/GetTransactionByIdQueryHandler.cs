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
    public class GetTransactionByIdQueryHandler : IBaseQueryHandler<GetTransactionByIdQuery, TransactionResponseDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IMemberRepository _memberRepository;

        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository, IWalletRepository walletRepository, IMemberRepository memberRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _memberRepository = memberRepository;
        }

        public async Task<TransactionResponseDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new TransactionGetAllSpec();
            var transaction = await _transactionRepository.GetByIdAsync(request.Id, spec, cancellationToken);

            var debitWallet = await _walletRepository.GetByIdAsync(transaction.DebitWalletId, new WalletGetAllSpec(), cancellationToken)
               ?? throw new NotFoundException("Wallet not found!");

            PayerDto payer = null!;
            if (debitWallet.WalletType == WalletType.Member)
            {
                var member = await _memberRepository.GetByWalletIdAsync(transaction.DebitWalletId, cancellationToken)
                ?? throw new NotFoundException("Member not found!");

                payer = new PayerDto
                {
                    FullName = member.FullName,
                    PhoneNumber = "" //TODO: Fix This
                };
            }
            else
            {
                payer = new PayerDto
                {
                    FullName = "Fund",
                    PhoneNumber = "Fund"
                };
            }

            return new TransactionResponseDto
            {
                Amount = transaction.Amount,
                CreatedAt = transaction.CreatedAt,
                Id = transaction.Id,
                Document = transaction.Document,
                Status = transaction.TransactionStatus,
                Type = transaction.TransactionType,
                AmountPayable = debitWallet.Balance, //TODO: Add This Business
                Payer = payer
            };
        }
    }
}
