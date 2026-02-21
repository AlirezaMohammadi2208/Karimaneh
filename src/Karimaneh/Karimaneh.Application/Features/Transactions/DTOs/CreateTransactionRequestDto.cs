using Karimaneh.Domain.TransactionAgg;

namespace Karimaneh.Application.Features.Transactions.DTOs
{
    public class CreateTransactionRequestDto
    {
        public Guid DebitWalletId { get; set; }
        public Guid CreditWalletId { get; set; }
        public decimal Amount { get; set; }
        public string Document { get; set; }
        public TransactionType Type { get; set; }
    }
}
