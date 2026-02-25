using Common.Application.CQRS.Command;
using Karimaneh.Domain.RequestAgg.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Karimaneh.Application.Features.Requests.Command.CreateRequest
{
    public record CreateRequestCommand(Guid MemberId, decimal Amount,
             string Description, Guid UserId, List<Guid> membersId) : IBaseCommand<bool>
    {

    }
    //TODO Validation
}
