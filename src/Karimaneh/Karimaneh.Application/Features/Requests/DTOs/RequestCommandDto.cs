using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.DTOs
{
    public record RequestCommandDto (Guid MemberId, decimal Amount,
             string Description,  List<Guid> membersId)
    {
    }
}
