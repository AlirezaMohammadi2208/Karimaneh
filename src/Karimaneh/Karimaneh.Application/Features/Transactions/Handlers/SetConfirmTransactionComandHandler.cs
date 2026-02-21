using Karimaneh.Application.Features.Transactions.Commands;
using LoanManagementSystem.Application.Features.Transactions.Specifications;
using LoanManagementSystem.Application.Interfaces;
using LoanManagementSystem.Domain.Aggregates.TransactionAggregate;

namespace LoanManagementSystem.Application.Features.Requests.Handlers
{
    public class SetConfirmTransactionComandHandler : ICommandHandler<SetConfirmTransactionComand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public SetConfirmTransactionComandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(SetConfirmTransactionComand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id, new TransactionGetAllSpec(), cancellationToken);

            transaction.DebitWalletAccount.Debit(transaction.Amount);
            transaction.CreditWalletAccount.Credit(transaction.Amount);

            transaction.Confirm();

            await _transactionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
