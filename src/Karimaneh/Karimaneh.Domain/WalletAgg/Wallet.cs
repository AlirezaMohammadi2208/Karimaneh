using Ardalis.GuardClauses;
using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Karimaneh.Domain.WalletAgg.Events;

namespace Karimaneh.Domain.WalletAgg
{
    /// <summary>
    /// کیف پول
    /// </summary>
    public class Wallet : BaseEntity, IAggregateRoot
    {
        private Wallet(WalletType type)
        {
            Guard.Against.EnumOutOfRange(type, nameof(type));

            WalletType = type;
        }

#pragma warning disable CS8618 // Required by Entity Framework
        private Wallet() { }

        /// <summary>
        /// موجودی کیف پول
        /// </summary>
        public decimal Balance { get; private set; } = 0;
        public WalletType WalletType { get; private set; }


        public void Debit(decimal amount)
        {
            Guard.Against.NegativeOrZero(amount, nameof(amount));

            if (Balance < amount)
                throw new DomainException("Insufficient funds");

            Balance -= amount;
        }

        public void Credit(decimal amount)
        {
            Guard.Against.NegativeOrZero(amount, nameof(amount));

            Balance += amount;
        }
        public static Wallet Create(WalletType type, Guid userId)
        {
            Guard.Against.NullOrEmpty(userId, nameof(userId));

            var wallet = new Wallet(type);
            wallet.AddDomainEvent(new WalletCreatedEvent(wallet, userId));
            return wallet;
        }
    }
    public enum WalletType
    {
        Member,
        Fund
    }
}
