using FluentValidation;
using Karimaneh.Application.Features.Transactions.DTOs;

namespace Karimaneh.Application.Features.Transactions.Queries
{
    public class GetAllTransactionsQuery : IQuery<IEnumerable<TransactionResponseDto>>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class GetAllTransactionsQueryValidator : AbstractValidator<GetAllTransactionsQuery>
    {
        public GetAllTransactionsQueryValidator()
        {
            RuleFor(x => x.Limit)
             .GreaterThan(0)
             .LessThanOrEqualTo(25);

            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);
        }
    }
}
