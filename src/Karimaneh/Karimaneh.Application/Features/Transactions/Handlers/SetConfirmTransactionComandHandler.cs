using Common.Application.CQRS.Command;
using Karimaneh.Application.Features.Transactions.Commands;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class SetConfirmTransactionComandHandler : IBaseCommandHandler<SetConfirmTransactionComand>
    {
        public Task Handle(SetConfirmTransactionComand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
