using Common.Application.CQRS.Command;
using Karimaneh.Application.Features.Transactions.Commands;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class SetConfirmTransactionComandHandler : IBaseCommandHandler<SetConfirmTransactionCommand>
    {
        public Task Handle(SetConfirmTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
