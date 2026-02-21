using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.LoanAgg
{
    /// <summary>
    /// کلاس وام
    /// </summary>
    public class Loan : BaseEntity , IAggregateRoot
    {
        private Loan() //EF
        {
        }

        public Loan(DateTime startDate, decimal amount, int installmentCount,
            Guid requestId, LoanStatus loanStatus)
        {
            StartDate = startDate;
            Amount = amount;
            InstallmentCount = installmentCount;
            RequestId = requestId;
            LoanStatus = loanStatus;
        }
        /// <summary>
        /// زمان شروع شدن وام
        /// </summary>
        public DateTime StartDate { get; private set; }
        /// <summary>
        /// مبلغ وام
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// تعداد قسط های وام
        /// </summary>
        public int InstallmentCount { get; private set; }
        public Guid RequestId { get; private set; }
        /// <summary>
        /// وضعیت وام
        /// </summary>
        public LoanStatus LoanStatus { get; private set; }
        private readonly List<Installment> _installments = new();
        public IReadOnlyCollection<Installment> Instalments => _installments;
    }
    public enum LoanStatus
    {

    }
}
