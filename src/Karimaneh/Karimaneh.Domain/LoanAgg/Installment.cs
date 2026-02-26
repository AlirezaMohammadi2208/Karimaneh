using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Karimaneh.Domain.LoanAgg.Events;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
        public Installment(Guid loanId, decimal amount, DateOnly dueDate)
        {
            ValueGuard(amount);
            LoanId = loanId;
            DueDate = dueDate;
            Amount = amount;
        }

        public Guid LoanId { get; private set; }
        /// <summary>
        /// تاریخ سر رسید قسط
        /// </summary>
        public DateOnly DueDate { get; private set; }
        /// <summary>
        /// مبلغ قسط
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// وضعیت قسط
        /// </summary>
        public InstallmentStatus InstallmentStatus { get; private set; } = InstallmentStatus.NotPiad;

        public static Installment Create(Guid loanId, decimal amount, DateOnly dueDate, Guid userId)
        {
            var installment = new Installment(loanId, amount, dueDate);
            installment.AddDomainEvent(new InstallmentCreatedEvent(installment, userId));
            return installment;
        }

        public void Payment(Guid transactionId)
        {
            InstallmentStatus = InstallmentStatus.Paid;
        }

        #region Validation
        private void ValueGuard(decimal amount)
        {
            if (amount <= 0)
                throw new DomainException("مقدار قسط نمیتواند کمتر از صفر باشد");
        }
        #endregion
    }
}
