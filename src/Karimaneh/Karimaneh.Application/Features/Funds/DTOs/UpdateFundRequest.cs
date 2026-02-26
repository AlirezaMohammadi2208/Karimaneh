using Common.Domain.ValueObjects;
using Karimaneh.Domain.FundAgg.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Funds.DTOs
{
    public class UpdateFundRequest
    {
        public int MaxConcurrentLoans { get; set; }
        public bool HasNoOverDueDebt { get; set; }
        public decimal MinLoanAmount { get; set; }
        public decimal MaxLoanAmount { get; set; }
        public decimal MemberShipFee { get; set; }
        public int InstallmentCount { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public BankInfo BankInfo { get; set; }
    }
}
