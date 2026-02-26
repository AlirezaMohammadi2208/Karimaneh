using MediatR;

namespace Karimaneh.Domain.LoanAgg.Events
{
    public class InstallmentCreatedEvent : INotification
    {
        public Installment Installment { get; }
        public Guid UserId { get; }

        public InstallmentCreatedEvent(Installment installment, Guid userId)
        {
            Installment = installment;
            UserId = userId;
        }
    }
}
