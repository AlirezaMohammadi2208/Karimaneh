using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Karimaneh.Domain.MemeberAgg
{
    /// <summary>
    /// اعضا
    /// </summary>
    public class Member : BaseEntity , IAggregateRoot
    {
        public Member(string firstName, string lastName, NationalCode nationalCode,
            string fatherName, BankInfo bankInfo, string avatarName, bool loanRequest, 
            Guid walletId, DebtStatus debtStatus, decimal debtAmount, decimal depositeBalance,
            decimal totalRecivedLoanAmount)
        {
            ValueGuard(firstName, lastName, fatherName, debtAmount, depositeBalance, totalRecivedLoanAmount);
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            FatherName = fatherName;
            BankInfo = bankInfo;
            AvatarName = avatarName;
            LoanRequest = loanRequest;
            WalletId = walletId;
            DebtStatus = debtStatus;
            DebtAmount = debtAmount;
            DepositeBalance = depositeBalance;
            TotalRecivedLoanAmount = totalRecivedLoanAmount;
        }

        private Member() { }//EF
        /// <summary>
        /// اسم
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// فامیلی
        /// </summary>
        public string LastName { get; private set; }
        //TODO : Create National Code VO
        /// <summary>
        /// کد ملی
        /// </summary>
        public NationalCode NationalCode { get; private set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string FatherName { get; private set; }
        /// <summary>
        /// اطلاعات بانکی
        /// </summary>
        public BankInfo BankInfo { get; private set; }
        /// <summary>
        /// اسم اواتار
        /// </summary>
        public string AvatarName { get; private set; }
        /// <summary>
        /// آیا مجوز  درخواست وام داره؟
        /// </summary>
        public bool LoanRequest { get; private set; }
        public Guid WalletId { get; private set; }
        /// <summary>
        /// وضعیت بدهی
        /// </summary>
        public DebtStatus DebtStatus { get; private set; }
        /// <summary>
        /// مقدار بدهی
        /// </summary>
        public decimal DebtAmount { get; private set; }
        /// <summary>
        /// موجودی سپرده
        /// </summary>
        public decimal DepositeBalance { get; private set; }
        /// <summary>
        /// مبلغ کل وام های گرفته شده
        /// </summary>
        public decimal TotalRecivedLoanAmount { get; private set; }


        #region Validation
        public void ValueGuard(string firstName, string lastName,
            string fatherName, decimal debtAmount, decimal depositeBalance,
            decimal totalRecivedLoanAmount)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("نام نمیتواند خالی باشد");
            if (!string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("نام خانوادگی نمیتواند خالی باشد");
            if (!string.IsNullOrWhiteSpace(fatherName))
                throw new DomainException("نام پدر نمیتواند خالی باشد");
            if (debtAmount < 0 || depositeBalance < 0 || totalRecivedLoanAmount < 0)
                throw new DomainException("نمیتواند کمتر از صفر باشد");

        }
        #endregion
    }
}
