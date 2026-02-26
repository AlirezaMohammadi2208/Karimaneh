using Karimaneh.Domain.LoanAgg;

namespace Karimaneh.Application.Features.Loans.DTOs
{
    public class InstallmentResponseDto
    {
        public Guid Id { get; set; }
        public Guid LoanId { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DueDate { get; set; }
        public InstallmentStatus InstallmentStatus { get; set; }
        public Guid? TransactionId { get; set; }
    }
}
