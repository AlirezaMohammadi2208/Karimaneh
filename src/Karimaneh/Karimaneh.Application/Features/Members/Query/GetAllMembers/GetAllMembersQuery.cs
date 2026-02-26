using Common.Application.CQRS.Query;
using FluentValidation;
using Karimaneh.Application.Features.Members.DTOs;

namespace Karimaneh.Application.Features.Members.Query.GetAllMembers
{
    public class GetAllMembersQuery : IBaseQuery<IEnumerable<MemberResponseDto>>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class GetAllMembersQueryValidator : AbstractValidator<GetAllMembersQuery>
    {
        public GetAllMembersQueryValidator()
        {
            RuleFor(x => x.Limit)
             .GreaterThan(0)
             .LessThanOrEqualTo(25);

            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);
        }
    }
}
