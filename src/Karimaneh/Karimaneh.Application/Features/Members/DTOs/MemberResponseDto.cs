using Common.Domain.ValueObjects;
using Karimaneh.Domain.MemeberAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Members.DTOs
{
    public class MemberResponseDto
    {
        public string FullName { get; set; }
        public NationalCode NationalCode { get; set; }
        public string FatherName { get; set; }
        public BankInfo BankInfo { get; set; }
        public string AvatarName { get; set; }
        public bool LoanRequest { get; set; }
        public Guid WalletId { get; set; }
        public DebtStatus DebtStatus { get; set; }
        public decimal DebtAmount { get; set; } = 0;
        public decimal DepositeBalance { get; set; } = 0;
        public decimal TotalRecivedLoanAmount { get; set; } = 0;

    }
}
