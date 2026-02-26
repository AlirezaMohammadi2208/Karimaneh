using Common.Application.CQRS.Query;
using FluentValidation;
using Karimaneh.Application.Features.Requests.DTOs;
using Karimaneh.Application.Features.Wallets.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.Query.GetAllRequest
{
    public class GetAllRequestQuery : IBaseQuery<List<RequestByIdDto>>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    public class GetAllRequestQueryValidator : AbstractValidator<GetAllRequestQuery>
    {
        public GetAllRequestQueryValidator()
        {
            RuleFor(x => x.Limit)
             .GreaterThan(0)
             .LessThanOrEqualTo(25);

            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);
        }
    }
}
