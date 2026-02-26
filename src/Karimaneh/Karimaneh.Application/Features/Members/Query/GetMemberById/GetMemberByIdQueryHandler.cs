using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Members.DTOs;
using Karimaneh.Domain.MemeberAgg.Repository;

namespace Karimaneh.Application.Features.Members.Query.GetMemberById
{
    public class GetMemberByIdQueryHandler : IBaseQueryHandler<GetMemberByIdQuery, MemberResponseDto>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetMemberByIdQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<MemberResponseDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetMemberById(request.Id);
            return _mapper.Map<MemberResponseDto>(member);
        }
    }
}
