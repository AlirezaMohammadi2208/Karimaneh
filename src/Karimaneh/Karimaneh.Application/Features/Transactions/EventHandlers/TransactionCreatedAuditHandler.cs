using Karimaneh.Domain.TransactionAgg.Events;
using MediatR;

namespace Karimaneh.Application.Features.Transactions.EventHandlers
{
    public class TransactionCreatedAuditHandler : INotificationHandler<TransactionCreatedEvent>
    {
        public Task Handle(TransactionCreatedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
