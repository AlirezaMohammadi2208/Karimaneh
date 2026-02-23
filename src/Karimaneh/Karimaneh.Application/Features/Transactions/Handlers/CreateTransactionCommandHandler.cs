using Common.Application.CQRS.Command;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Transactions.Commands;
using Karimaneh.Application.Idempotency;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.TransactionAgg;
using Karimaneh.Domain.TransactionAgg.Repository;
using Karimaneh.Domain.WalletAgg.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class CreateTransactionCommandHandler : IBaseCommandHandler<CreateTransactionCommand, bool>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
        }

        public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            if (request.DebitWalletId == request.CreditWalletId)
                throw new ConflictException("The parties to the transaction are the same.");

            var transaction = Transaction.Create(
                request.DebitWalletId,
                request.CreditWalletId,
                request.Amount,
                request.Document,
                request.Type,
                request.UserId);

            await _transactionRepository.AddAsync(transaction, cancellationToken);

            return true;
        }
    }

    // Use for Idempotency in Command process
    public class CreateTransactionIdentifiedCommandHandler : IdentifiedCommandHandler<CreateTransactionCommand, bool>
    {
        public CreateTransactionIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<CreateTransactionCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true; // Ignore duplicate requests for processing transaction.
        }
    }
}
