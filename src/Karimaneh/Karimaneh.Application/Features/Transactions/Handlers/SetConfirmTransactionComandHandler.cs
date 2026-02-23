using Common.Application.CQRS.Command;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Transactions.Commands;
using Karimaneh.Application.Features.Transactions.Specifications;
using Karimaneh.Application.Features.Wallets.Specifications;
using Karimaneh.Domain.TransactionAgg.Repository;
using Karimaneh.Domain.WalletAgg.Repository;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class SetConfirmTransactionComandHandler : IBaseCommandHandler<SetConfirmTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;

        public SetConfirmTransactionComandHandler(ITransactionRepository transactionRepository, IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
        }

        public async Task Handle(SetConfirmTransactionComand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id, new TransactionGetAllSpec(), cancellationToken)
                ?? throw new NotFoundException("Transaction Not Found!");

            var debitWallet = await _walletRepository.GetByIdAsync(transaction.DebitWalletId, new WalletGetAllSpec(), cancellationToken)
                ?? throw new NotFoundException("Wallet Not Found!");

            var creditWallet = await _walletRepository.GetByIdAsync(transaction.CreditWalletId, new WalletGetAllSpec(), cancellationToken)
                ?? throw new NotFoundException("Wallet Not Found!");

            debitWallet.Debit(transaction.Amount);
            creditWallet.Credit(transaction.Amount);

            transaction.Confirm();

            await _transactionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
