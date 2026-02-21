using Common.Application.CQRS.Command;
using FluentValidation;
using Karimaneh.Domain.TransactionAgg;

namespace Karimaneh.Application.Features.Transactions.Commands
{
    public class CreateTransactionCommand : IBaseCommand<bool>
    {
        public Guid DebitWalletId { get; set; }
        public Guid CreditWalletId { get; set; }
        public decimal Amount { get; set; }
        public string Document { get; set; }
        public TransactionType Type { get; set; }
        public Guid UserId { get; set; }
    }

    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.DebitWalletId)
       .NotEmpty();

            RuleFor(x => x.CreditWalletId)
       .NotEmpty();

        }
    }
}
