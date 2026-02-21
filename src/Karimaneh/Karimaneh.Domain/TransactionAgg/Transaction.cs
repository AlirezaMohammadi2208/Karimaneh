using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.TransactionAgg
{
    /// <summary>
    /// تراکنش
    /// </summary>
    public class Transaction : BaseEntity, IAggregateRoot
    {
        public Transaction(Guid debitWalletId, Guid creditWalletId,
            decimal amount, TransactionType transactionType, DateTime createdAt,
            string document)
        {
            DebitWalletId = debitWalletId;
            CreditWalletId = creditWalletId;
            Amount = amount;
            TransactionType = transactionType;
            CreatedAt = createdAt;
            Document = document;
        }

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
        /// <summary>
        /// زمان تراکنش
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        /// <summary>
        /// اسم فایل سند تراکنش
        /// </summary>
        public string Document { get; private set; }
    }
    public enum TransactionType
    {

    }
}
