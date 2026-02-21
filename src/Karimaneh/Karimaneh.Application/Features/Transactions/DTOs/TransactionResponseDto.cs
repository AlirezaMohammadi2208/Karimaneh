using Karimaneh.Domain.TransactionAgg;

namespace Karimaneh.Application.Features.Transactions.DTOs
{
    public class TransactionResponseDto
    {
        public Guid Id { get; set; }
        public PayerDto Payer { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal AmountPayable { get; set; }
        public string Document { get; set; }
    }
    public class PayerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
