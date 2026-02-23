using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.LoanAgg
{
    /// <summary>
    /// کلاس وام
    /// </summary>
    public partial class Loan : BaseEntity, IAggregateRoot
    {
        private Loan() //EF
        {
        }

        public Loan(DateTime startDate, decimal amount, int installmentCount,
            Guid requestId, LoanStatus loanStatus)
        {
            ValueGuard(amount, installmentCount);
            StartDate = startDate;
            Amount = amount;
            InstallmentCount = installmentCount;
            RequestId = requestId;
            Status = loanStatus;
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
        public LoanStatus Status { get; private set; }
        private readonly List<Installment> _installments = new();
        public IReadOnlyCollection<Installment> Instalments => _installments;

        #region Validation
        public void ValueGuard(decimal amount, int installmentCount)
        {
            if (amount <= 0)
                throw new DomainException("مقدار وام نمیتواند کمتر از صفر باشد");
            if (installmentCount <= 0)
                throw new DomainException("تعداد اقساط وام نمیتواند کمتر از صفر باشد");
        }

        #endregion
    }
}