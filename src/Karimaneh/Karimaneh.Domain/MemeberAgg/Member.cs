using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Karimaneh.Domain.MemeberAgg.Evenet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace Karimaneh.Domain.MemeberAgg
{
    /// <summary>
    /// اعضا
    /// </summary>
    public class Member : BaseEntity, IAggregateRoot
    {
        private Member(string fullName, NationalCode nationalCode,
            string fatherName, BankInfo bankInfo, string avatarName, bool loanRequest,
            Guid walletId, DebtStatus debtStatus)
        {
            ValueGuard(fullName, fatherName);
            FullName = fullName;
            NationalCode = nationalCode;
            FatherName = fatherName;
            BankInfo = bankInfo;
            AvatarName = avatarName;
            LoanRequest = loanRequest;
            WalletId = walletId;
            DebtStatus = debtStatus;
        }

        private Member() { }//EF
        /// <summary>
        /// اسم
        /// </summary>
        public string FullName { get; private set; }
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
        /// فعال بودن عضو
        /// </summary>
        public bool MembersStatus { get; private set; }
        /// <summary>
        /// مقدار بدهی
        /// </summary>
        public decimal DebtAmount { get; private set; } = 0;
        /// <summary>
        /// موجودی سپرده
        /// </summary>
        public decimal DepositeBalance { get; private set; } = 0;
        /// <summary>
        /// مبلغ کل وام های گرفته شده
        /// </summary>
        public decimal TotalRecivedLoanAmount { get; private set; } = 0;

        public static Member Create(string fullName, NationalCode nationalCode,
            string fatherName, BankInfo bankInfo, string avatarName, bool loanRequest,
            Guid walletId, DebtStatus debtStatus, Guid userId)
        {
            var member = new Member(fullName, nationalCode, fatherName
                , bankInfo, avatarName, loanRequest, walletId, DebtStatus.NotHave);
            member.AddDomainEvent(new MemberCreatedEvent(userId, member));
            return member;
        }
        public void ChangeStatus(bool memberStatus)
        {
            
        }
        #region Validation
        private void ValueGuard(string fullName,
            string fatherName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new DomainException("نام نمیتواند خالی باشد");
            if (string.IsNullOrWhiteSpace(fatherName))
                throw new DomainException("نام پدر نمیتواند خالی باشد");


        }
        #endregion
    }
    
}
