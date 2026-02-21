using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.WalletAgg
{
    /// <summary>
    /// کیف پول
    /// </summary>
    public class Wallet : BaseEntity, IAggregateRoot
    {
        private Wallet() { } //EF

        public Wallet(decimal balance)
        {
            Balance = balance;
        }

        private readonly List<Transaction> _debitTransactions = new();
        public IReadOnlyCollection<Transaction> DebitTransactions => _debitTransactions;
        private readonly List<Transaction> _creditTransactions = new();
        public IReadOnlyCollection<Transaction> CreditTransactions => _creditTransactions;
        /// <summary>
        /// موجودی کیف پول
        /// </summary>
        public decimal Balance { get; private set; }
    }
    
}
