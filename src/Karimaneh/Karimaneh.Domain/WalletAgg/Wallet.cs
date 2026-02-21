using Common.Domain.BaseModels;
using Karimaneh.Domain.TransactionAgg;
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

        /// <summary>
        /// موجودی کیف پول
        /// </summary>
        public decimal Balance { get; private set; }
    }
}
