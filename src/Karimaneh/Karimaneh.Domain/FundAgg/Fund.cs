using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.FundAgg
{
    /// <summary>
    ///  کلاس صندوق
    /// </summary>
    public class Fund : BaseEntity , IAggregateRoot
    {
        public Fund(int maxConcurrentLoans, bool hasNoOverDueDebt, decimal minLoanAmount,
            decimal maxLoanAmount, decimal memberShipFee, int installmentCount,
            GuaranteeType guaranteeType, Guid walletId)
        {
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
        {        }
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
        //TODO : ساخت VO بانک اینفو
        public BankInfo BankInfo { get; private set; }
    }
    public enum GuaranteeType
    {

    }
}
