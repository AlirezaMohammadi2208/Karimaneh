using MediatR;

namespace Karimaneh.Domain.FundAgg.Events
{
    public class FundCreatedEvent : INotification
    {
        public Fund Fund { get; }
        public Guid UserId { get; }

        public FundCreatedEvent(Fund fund, Guid userId)
        {
            Fund = fund;
            UserId = userId;
        }
    }
}
