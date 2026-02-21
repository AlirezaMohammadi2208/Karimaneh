using MediatR;

namespace Karimaneh.Domain.WalletAgg.Events
{
    public class WalletCreatedEvent : INotification
    {
        public Wallet Wallet { get; }
        public Guid UserId { get; }

        public WalletCreatedEvent(Wallet wallet, Guid userId)
        {
            Wallet = wallet;
            UserId = userId;
        }
    }
}
