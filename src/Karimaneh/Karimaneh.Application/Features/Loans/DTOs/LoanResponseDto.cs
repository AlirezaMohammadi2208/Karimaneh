namespace Karimaneh.Application.Features.Loans.DTOs
{
    public class LoanResponseDto
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public Guid MemberId { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentCount { get; set; }
    }
}
