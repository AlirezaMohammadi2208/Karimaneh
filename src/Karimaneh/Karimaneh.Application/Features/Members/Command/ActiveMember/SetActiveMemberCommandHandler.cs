using Common.Application.CQRS.Command;
using Common.Application.Exceptions;
using Karimaneh.Domain.MemeberAgg.Repository;

namespace Karimaneh.Application.Features.Members.Command.ActiveMember
{
    public class SetActiveMemberCommandHandler : IBaseCommandHandler<SetActiveMemberCommand>
    {
        private readonly IMemberRepository _memberRepository;

        public SetActiveMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Handle(SetActiveMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetMemberById(request.Id)
                ?? throw new NotFoundException("Member NotFound!");

            member.Active(request.UserId, "DeActive");

            await _memberRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
