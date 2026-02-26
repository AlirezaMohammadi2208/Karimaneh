using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Requests.DTOs;
using Karimaneh.Application.Features.Requests.Mapping;
using Karimaneh.Application.Features.Requests.Specifications;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Domain.RequestAgg.Repository;
using System.Net;

namespace Karimaneh.Application.Features.Requests.Query.GetAllRequest
{
    public class GetAllRequestQueryHandler : IBaseQueryHandler<GetAllRequestQuery, List<RequestByIdDto>>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetAllRequestQueryHandler(IRequestRepository requestRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<List<RequestByIdDto>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
        {
            var spec = new RequestGetAllSpec(request.Limit, request.Offset);
            var requests = await _requestRepository.GetAllAsync(spec, cancellationToken);
            var response = new List<RequestByIdDto>();

            foreach (var x in requests)
            {

                var member = await _memberRepository.GetMemberById(x.MemberId);

                var requestDto = x.ByIdMapping(member);
                var guarantorsDto = (await Task.WhenAll(x.Guarantors.Select(async x =>
                {
                    var guarantor = await _memberRepository.GetMemberById(x.MemeberId);
                    return guarantor.GuarantorMapping();
                }))).ToList();
                requestDto.Guarantors = guarantorsDto;
                response.Add(requestDto);
            }
            ;
            return response;

        }
    }
}
