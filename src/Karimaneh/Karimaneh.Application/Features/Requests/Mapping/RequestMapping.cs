using Karimaneh.Application.Features.Requests.Command.CreateRequest;
using Karimaneh.Application.Features.Requests.DTOs;
using Karimaneh.Domain.MemeberAgg;
using Karimaneh.Domain.RequestAgg;
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
        public static RequestByIdDto ByIdMapping(this Request request , Member member)
        {
            return new RequestByIdDto
            {
                Amount = request.Amount,
                Description = request.Description,
                RequestDate = request.RequestDate,
                RequestId = request.Id,
                RequestStatus = request.RequestStatus,
                FullName = member.FullName,
                DebtStatus =  member.DebtStatus,
                NationalCode = member.NationalCode.Value,
                PhoneNumber = member.PhoneNumber.Value,
            };
        }
        public static GuarantorDto GuarantorMapping(this Member member)
        {
            return new GuarantorDto
            {
                DebtAmount = member.DebtAmount,
                DebtStatus = member.DebtStatus,
                NationalCode = member.NationalCode.Value,
            };
        }
    }
}
