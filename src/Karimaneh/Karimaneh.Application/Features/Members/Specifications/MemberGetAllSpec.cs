namespace Karimaneh.Application.Features.Members.Specifications
{
    public class MemberGetAllSpec : MemberBaseSpec
    {
        public MemberGetAllSpec(int? limit = null, int? offset = null)
        {
            if (limit is not null && offset is not null)
            {
                ApplyPaging(offset.Value, limit.Value);
            }
        }
    }
}
