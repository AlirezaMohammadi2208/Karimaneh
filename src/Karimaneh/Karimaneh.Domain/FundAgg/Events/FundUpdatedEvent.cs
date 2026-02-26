using MediatR;

namespace Karimaneh.Domain.FundAgg.Events
{
    public class FundUpdatedEvent : INotification
    {
        public Fund Fund { get; }
        public string? OldValue { get; }
        public Guid UserId { get; }

        public FundUpdatedEvent(Fund fund, Guid userId, string? oldValue)
        {
            Fund = fund;
            UserId = userId;
            OldValue = oldValue;
        }
    }
}
