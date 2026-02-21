using Common.Application.CQRS.Command;
using Karimaneh.Application.Features.Transactions.Commands;
using Karimaneh.Application.Idempotency;
using Karimaneh.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class CreateTransactionCommandHandler : IBaseCommandHandler<CreateTransactionCommand, bool>
    {
        public Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
