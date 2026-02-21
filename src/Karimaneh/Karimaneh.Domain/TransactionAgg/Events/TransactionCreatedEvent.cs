
using MediatR;

namespace Karimaneh.Domain.TransactionAgg.Events
{
    public class TransactionCreatedEvent : INotification
    {
        public Transaction Transaction { get; }
        public Guid UserId { get; }

        public TransactionCreatedEvent(Transaction transaction, Guid userId)
        {
            Transaction = transaction;
            UserId = userId;
        }
    }
}
