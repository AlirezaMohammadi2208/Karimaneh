using FluentValidation;
using Karimaneh.Domain.TransactionAgg;

namespace Karimaneh.Application.Features.Transactions.Commands
{
    public class CreateTransactionCommand : ICommand<bool>
    {

    }

    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {


        }
    }
}
