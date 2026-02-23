using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.LoanAgg
{
    /// <summary>
    /// کلاس قسط
    /// </summary>
    public class Installment : BaseEntity
    {
        private Installment() //EF
        {
            
        }
        public Installment(Guid loanId, DateTime dueDate, 
            decimal amount, InstallmentStatus installmentStatus)
        {
            ValueGuard(amount);
            LoanId = loanId;
            DueDate = dueDate;
            Amount = amount;
            InstallmentStatus = installmentStatus;
        }

        public Guid LoanId { get; private set; }
        /// <summary>
        /// تاریخ سر رسید قسط
        /// </summary>
        public DateTime DueDate { get; private set; }
        /// <summary>
        /// مبلغ قسط
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// وضعیت قسط
        /// </summary>
        public InstallmentStatus InstallmentStatus { get; private set; }

        #region Validation
        public void ValueGuard(decimal amount)
        {
            if (amount <= 0)
                throw new DomainException("مقدار قسط نمیتواند کمتر از صفر باشد");
        }
        #endregion
    }
}
