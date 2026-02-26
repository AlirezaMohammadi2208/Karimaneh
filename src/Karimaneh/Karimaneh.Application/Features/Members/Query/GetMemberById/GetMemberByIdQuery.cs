using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Members.DTOs;

namespace Karimaneh.Application.Features.Members.Query.GetMemberById
{
    public class GetMemberByIdQuery : IBaseQuery<MemberResponseDto>
    {
        public Guid Id { get; set; }
    }
}
