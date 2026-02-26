using Common.Application.CQRS.Command;
using Common.Application.Exceptions;
using Karimaneh.Domain.MemeberAgg.Repository;

namespace Karimaneh.Application.Features.Members.Command.DeActiveMember
{
    public class SetDeActiveMemberCommandHandler : IBaseCommandHandler<SetDeActiveMemberCommand>
    {
        private readonly IMemberRepository _memberRepository;

        public SetDeActiveMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Handle(SetDeActiveMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetMemberById(request.Id)
                ?? throw new NotFoundException("Member NotFound!");

            member.DeActive(request.UserId, "Active");

            await _memberRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
