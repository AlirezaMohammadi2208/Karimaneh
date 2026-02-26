using Common.Domain.ValueObjects;
using Karimaneh.Domain.FundAgg.Enum;
using System.Text.Json.Serialization;

namespace Karimaneh.Application.Features.Funds.DTOs
{
    public class FundResponseDto
    {
        public decimal MinLoanAmount { get; set; }
        public decimal MaxLoanAmount { get; set; }
        public decimal MembershipFee { get; set; }
        public int InstallmentCount { get; set; }
        public int MaxConcurrentLoans { get; set; }


        [JsonConverter(typeof(JsonStringEnumDisplayConverter<GuaranteeType>))]
        public GuaranteeType GuaranteeType { get; set; }

        public BankInfo BankAccountInfo { get; set; }
    }
}
