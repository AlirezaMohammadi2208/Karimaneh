using Ardalis.GuardClauses;
using Common.Domain.BaseModels;
using Karimaneh.Domain.TransactionAgg.Events;

namespace Karimaneh.Domain.TransactionAgg
{
    /// <summary>
    /// تراکنش
    /// </summary>
    public class Transaction : BaseEntity, IAggregateRoot
    {
        private Transaction(
             Guid debitWalletId,
             Guid creditWalletId,
             decimal amount,
             string document,
             TransactionType type)
        {
            Guard.Against.NullOrEmpty(debitWalletId, nameof(debitWalletId));
            Guard.Against.NullOrEmpty(creditWalletId, nameof(creditWalletId));
            Guard.Against.NegativeOrZero(amount, nameof(amount));
            Guard.Against.NullOrEmpty(document, nameof(document));
            Guard.Against.EnumOutOfRange(type, nameof(type));

            DebitWalletId = debitWalletId;
            CreditWalletId = creditWalletId;
            Amount = amount;
            Document = document;
            TransactionType = type;
        }

#pragma warning disable CS8618 // Required by Entity Framework
        private Transaction() { } //EF

        public Guid DebitWalletId { get; private set; }
        public Guid CreditWalletId { get; private set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// تایپ تراکنش 
        /// </summary>
        public TransactionType TransactionType { get; private set; }

        public TransactionStatus TransactionStatus { get; private set; } = TransactionStatus.Pending;

        /// <summary>
        /// زمان تراکنش
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        /// <summary>
        /// اسم فایل سند تراکنش
        /// </summary>
        public string Document { get; private set; }

        public static Transaction Create(
        Guid debitWalletId,
        Guid creditWalletId,
        decimal amount,
        string document,
        TransactionType type,
        Guid userId)
        {
            Guard.Against.NullOrEmpty(userId, nameof(userId));

            var transaction = new Transaction(debitWalletId, creditWalletId, amount, document, type);
            transaction.AddDomainEvent(new TransactionCreatedEvent(transaction, userId));
            return transaction;
        }

        public void Confirm()
        {
            TransactionStatus = TransactionStatus.Confirmed;
        }
    }
    public enum TransactionType
    {
        LoanPayment,
        InstallmentPayment,
        SubscriptionPayment
    }
    public enum TransactionStatus
    {
        Pending,
        Confirmed,
        Rejected
    }

}
