using Common.Application.CQRS.Query;
using FluentValidation;
using Karimaneh.Application.Features.Wallets.DTOs;

namespace Karimaneh.Application.Features.Wallets.Queries
{
    public class GetAllWalletsQuery : IBaseQuery<IEnumerable<WalletResponseDto>>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class GetAllWalletsQueryValidator : AbstractValidator<GetAllWalletsQuery>
    {
        public GetAllWalletsQueryValidator()
        {
            RuleFor(x => x.Limit)
             .GreaterThan(0)
             .LessThanOrEqualTo(25);

            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);
        }
    }
}
