using Common.Application.CQRS.Command;
using Common.Domain.ValueObjects;
using Karimaneh.Domain.FundAgg.Enum;

namespace Karimaneh.Application.Features.Funds.Commands
{
    public class UpdateFundCommand : IBaseCommand<bool>
    {
        public int MaxConcurrentLoans { get; set; }
        public bool HasNoOverDueDebt { get; set; }
        public decimal MinLoanAmount { get; set; }
        public decimal MaxLoanAmount { get; set; }
        public decimal MemberShipFee { get; set; }
        public int InstallmentCount { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public BankInfo BankInfo { get; set; }
        public Guid UserId { get; set; }
    }
}
