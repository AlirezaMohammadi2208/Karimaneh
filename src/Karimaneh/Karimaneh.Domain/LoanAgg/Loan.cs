using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Karimaneh.Domain.LoanAgg.Events;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

        public Loan(DateOnly startDate, decimal amount, int installmentCount,
            Guid requestId)
        {
            ValueGuard(amount, installmentCount);
            StartDate = startDate;
            Amount = amount;
            InstallmentCount = installmentCount;
            RequestId = requestId;
        }
        /// <summary>
        /// زمان شروع شدن وام
        /// </summary>
        public DateOnly StartDate { get; private set; }
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

        public static Loan Create(
            DateOnly startDate,
            decimal amount,
            int installmentCount,
            Guid requestId,
            Guid userId)
        {
            var loan = new Loan(startDate, amount, installmentCount, requestId);
            loan.AddDomainEvent(new LoanCreatedEvent(loan, userId));
            return loan;
        }

        public void CreateLoanInstallments(Guid userId, decimal profitRate = 0)
        {
            if (InstallmentCount <= 0)
                throw new DomainException("تعداد اقساط نمیتواند صفر یا زیر صفر باشد.");

            var totalWithProfit = Amount + (Amount * profitRate / 100m);
            var baseInstallment = Math.Floor(totalWithProfit / InstallmentCount);
            var remainder = totalWithProfit - (baseInstallment * InstallmentCount);

            for (int i = 1; i <= InstallmentCount; i++)
            {
                var installmentAmount = baseInstallment;

                if (i == InstallmentCount)
                    installmentAmount += remainder;

                _installments.Add(Installment.Create(Id, installmentAmount, StartDate.AddMonths(i), userId));
            }
        }

        #region Validation
        private void ValueGuard(decimal amount, int installmentCount)
        {
            if (amount <= 0)
                throw new DomainException("مقدار وام نمیتواند کمتر از صفر باشد");
            if (installmentCount <= 0)
                throw new DomainException("تعداد اقساط وام نمیتواند کمتر از صفر باشد");
        }

        #endregion
    }
}