using Ardalis.GuardClauses;
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
            Guid walletId, DebtStatus debtStatus, PhoneNumber phoneNumber)
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
            PhoneNumber = phoneNumber;
        }

        private Member() { }//EF
        /// <summary>
        /// اسم
        /// </summary>
        public string FullName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
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
        public bool MemberStatus { get; private set; } = true;
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
            Guid walletId, DebtStatus debtStatus, Guid userId, PhoneNumber phoneNumber)
        {
            var member = new Member(fullName, nationalCode, fatherName
                , bankInfo, avatarName, loanRequest, walletId, DebtStatus.NotHave, phoneNumber);
            member.AddDomainEvent(new MemberCreatedEvent(userId, member));
            return member;
        }
        public void Active(Guid userId, string oldValue)
        {
            Guard.Against.NullOrEmpty(userId, nameof(userId));
            Guard.Against.NullOrEmpty(oldValue, nameof(oldValue));

            MemberStatus = true;
            AddDomainEvent(new MemberUpdatedEvent(this, userId, oldValue));
        }

        public void DeActive(Guid userId, string oldValue)
        {
            Guard.Against.NullOrEmpty(userId, nameof(userId));
            Guard.Against.NullOrEmpty(oldValue, nameof(oldValue));

            MemberStatus = false;
            AddDomainEvent(new MemberUpdatedEvent(this, userId, oldValue));
        }
        public Member Edit(
        NationalCode nationalCode,
        string fullName,
        PhoneNumber phoneNumber,
        BankInfo bankInfo,
        bool memberStatus,
        Guid userId,
        string oldValue)
        {
            Guard.Against.Null(nationalCode, nameof(nationalCode));
            Guard.Against.NullOrEmpty(fullName, nameof(fullName));
            Guard.Against.Null(phoneNumber, nameof(phoneNumber));
            Guard.Against.NullOrEmpty(userId, nameof(userId));
            Guard.Against.NullOrEmpty(oldValue, nameof(oldValue));
            Guard.Against.Null(bankInfo, nameof(bankInfo));

            NationalCode = nationalCode;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            BankInfo = bankInfo;
            MemberStatus = memberStatus;
            AddDomainEvent(new MemberUpdatedEvent(this, userId, oldValue));
            return this;
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
