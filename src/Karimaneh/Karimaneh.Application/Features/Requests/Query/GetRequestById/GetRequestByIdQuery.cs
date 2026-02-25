using Common.Application.CQRS.Query;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Requests.DTOs;
using Karimaneh.Application.Features.Requests.Mapping;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Domain.RequestAgg.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace Karimaneh.Application.Features.Requests.Query.GetRequestById
{
    public record GetRequestByIdQuery(Guid ReqestId) : IBaseQuery<RequestByIdDto?>
    {

    }
    public class GetRequestByIdQueryHandler : IBaseQueryHandler<GetRequestByIdQuery, RequestByIdDto?>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMemberRepository _memberRepository;
        public GetRequestByIdQueryHandler(IRequestRepository requestRepository, IMemberRepository memberRepository)
        {
            _requestRepository = requestRepository;
            _memberRepository = memberRepository;
        }

        public async Task<RequestByIdDto?> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var newRequest = await _requestRepository.GetRequestById(request.ReqestId)
            ?? throw new NotFoundException("درخواست پیدا نشد");
            var member = await _memberRepository.GetMemberById(newRequest.MemberId);

            var requestDto = newRequest.ByIdMapping(member);
            var guarantorsDto =(await Task.WhenAll(newRequest.Guarantors.Select(async x =>
            {
                var guarantor = await _memberRepository.GetMemberById(x.MemeberId);
                return guarantor.GuarantorMapping();
            }))).ToList();
            requestDto.Guarantors = guarantorsDto;
            return requestDto;
        }
    }
}
