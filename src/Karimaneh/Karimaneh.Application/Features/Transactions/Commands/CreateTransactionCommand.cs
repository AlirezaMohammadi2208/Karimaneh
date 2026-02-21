using Common.Application.CQRS.Command;
using FluentValidation;
using Karimaneh.Domain.TransactionAgg;

namespace Karimaneh.Application.Features.Transactions.Commands
{
    public class CreateTransactionCommand : IBaseCommand<bool>
    {
        public Guid UserId { get; set; }
    }

    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {


        }
    }
}
