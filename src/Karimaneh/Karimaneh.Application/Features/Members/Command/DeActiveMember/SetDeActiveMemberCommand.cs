using Common.Application.CQRS.Command;

namespace Karimaneh.Application.Features.Members.Command.DeActiveMember
{
    public class SetDeActiveMemberCommand : IBaseCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
