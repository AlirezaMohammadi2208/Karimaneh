using MediatR;

namespace Karimaneh.Domain.LoanAgg.Events
{
    public class LoanCreatedEvent : INotification
    {
        public Loan Loan { get; }
        public Guid UserId { get; }

        public LoanCreatedEvent(Loan loan, Guid userId)
        {
            Loan = loan;
            UserId = userId;
        }
    }
}
