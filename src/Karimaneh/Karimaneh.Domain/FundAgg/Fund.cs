using Ardalis.GuardClauses;
using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Karimaneh.Domain.FundAgg.Enum;
using Karimaneh.Domain.FundAgg.Events;

namespace Karimaneh.Domain.FundAgg
{
    /// <summary>
    ///  کلاس صندوق
    /// </summary>
    public class Fund : BaseEntity, IAggregateRoot
    {
        public Fund(int maxConcurrentLoans, bool hasNoOverDueDebt, decimal minLoanAmount,
            decimal maxLoanAmount, decimal memberShipFee, int installmentCount,
            GuaranteeType guaranteeType, Guid walletId)
        {
            ValueGuard(maxConcurrentLoans, minLoanAmount, maxLoanAmount, memberShipFee, installmentCount);
            Guard.Against.NegativeOrZero(maxConcurrentLoans, nameof(maxConcurrentLoans));

            MaxConcurrentLoans = maxConcurrentLoans;
            HasNoOverDueDebt = hasNoOverDueDebt;
            MinLoanAmount = minLoanAmount;
            MaxLoanAmount = maxLoanAmount;
            MemberShipFee = memberShipFee;
            InstallmentCount = installmentCount;
            GuaranteeType = guaranteeType;
            WalletId = walletId;
        }

        private Fund() //EF
        { }
        /// <summary>
        /// تعداد وام همزمان 
        /// </summary>
        public int MaxConcurrentLoans { get; private set; }
        /// <summary>
        /// نداشتن بدهی معوق برای درخواست وام
        /// </summary>
        public bool HasNoOverDueDebt { get; private set; }
        /// <summary>
        /// حداقل مبلغ وام 
        /// </summary>
        public decimal MinLoanAmount { get; private set; }
        /// <summary>
        /// حداکثر مبلغ وام 
        /// </summary>
        public decimal MaxLoanAmount { get; private set; }
        /// <summary>
        /// حق عضویت 
        /// </summary>
        public decimal MemberShipFee { get; private set; }
        /// <summary>
        /// تعداد قسط هر وام
        /// </summary>
        public int InstallmentCount { get; private set; }
        /// <summary>
        /// تایپ ضمانت
        /// </summary>
        public GuaranteeType GuaranteeType { get; private set; }
        public Guid WalletId { get; private set; }
        /// <summary>
        /// اطلاعات بانکی
        /// </summary>
        public BankInfo BankInfo { get; private set; }

        public Fund Edit(
            int maxConcurrentLoans,
            bool hasNoOverDueDebt,
            decimal minLoanAmount,
            decimal maxLoanAmount,
            decimal memberShipFee,
            int installmentCount,
            GuaranteeType guaranteeType,
            BankInfo bankInfo,
            Guid userId,
            string oldValue)
        {
            MaxConcurrentLoans = maxConcurrentLoans;
            HasNoOverDueDebt = hasNoOverDueDebt;
            MinLoanAmount = minLoanAmount;
            MaxLoanAmount = maxLoanAmount;
            MemberShipFee = memberShipFee;
            InstallmentCount = installmentCount;
            GuaranteeType = guaranteeType;
            BankInfo = bankInfo;

            AddDomainEvent(new FundUpdatedEvent(this, userId, oldValue));
            return this;
        }
        #region Validation
        private void ValueGuard(int maxConcurrentLoans, decimal minLoanAmount,
            decimal maxLoanAmount, decimal memberShipFee, int installmentCount)
        {
            if (maxConcurrentLoans <= 0 || maxConcurrentLoans > 5)
                throw new DomainException("وام های همزمان نمیتواند بیشتر از 5 و کمتر از صفر باشد");
            if (minLoanAmount <= 0)
                throw new DomainException("حداقل مقدار وام نمیتواند کمتر از صفر باشد");
            if (minLoanAmount > maxLoanAmount)
                throw new DomainException("حداقل مقدار وام نمیتواند بیشتر از حداکثر مقدار وام باشد");
            if (memberShipFee <= 0)
                throw new DomainException("مقدار حق اشتراک نمیتواند کمتر از صفر باشد");
            if (installmentCount <= 0)
                throw new DomainException("تعداد قسط ها نمیتواند کمتر از صفر باشد");
        }
        #endregion
    }
}
