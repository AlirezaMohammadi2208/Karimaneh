using Common.Application.CQRS.Command;

namespace Karimaneh.Application.Features.Members.Command.ActiveMember
{
    public class SetActiveMemberCommand : IBaseCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
