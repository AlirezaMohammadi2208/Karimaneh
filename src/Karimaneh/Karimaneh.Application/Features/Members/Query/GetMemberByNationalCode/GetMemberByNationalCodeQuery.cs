using Common.Application.CQRS.Query;
using Common.Domain.ValueObjects;
using Karimaneh.Domain.MemeberAgg;

namespace Karimaneh.Application.Features.Members.Query.GetMemberByNationalCode
{
    public class GetMemberByNationalCodeQuery : IBaseQuery<Member>
    {
        public NationalCode NationalCode { get; set; }
    }
}
