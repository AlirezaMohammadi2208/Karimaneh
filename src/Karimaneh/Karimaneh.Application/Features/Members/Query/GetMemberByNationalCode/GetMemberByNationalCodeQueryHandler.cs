using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Members.Specifications;
using Karimaneh.Domain.MemeberAgg;
using Karimaneh.Domain.MemeberAgg.Repository;

namespace Karimaneh.Application.Features.Members.Query.GetMemberByNationalCode
{
    public class GetMemberByNationalCodeQueryHandler : IBaseQueryHandler<GetMemberByNationalCodeQuery, Member>
    {
        private readonly IMemberRepository _memberRepository;

        public GetMemberByNationalCodeQueryHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> Handle(GetMemberByNationalCodeQuery request, CancellationToken cancellationToken)
        {
            var spec = new MemberGetAllSpec();

            return await _memberRepository.GetByNationalCodeAsync(request.NationalCode, spec, cancellationToken);
        }
    }
}
