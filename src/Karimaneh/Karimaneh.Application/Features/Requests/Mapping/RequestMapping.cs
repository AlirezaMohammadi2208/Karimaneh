using Karimaneh.Application.Features.Requests.CreateRequest;
using Karimaneh.Application.Features.Requests.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.Mapping
{
    public static class RequestMapping
    {
        public static CreateRequestCommand Mapping(this RequestCommandDto requestDto , Guid UserId)
        {
            var createCommand = new CreateRequestCommand
            (
                 requestDto.MemberId,
                 requestDto.Amount,
                 requestDto.Description,
                  UserId,
                requestDto.membersId
            ) ;
            return createCommand;
        }
    }
}
