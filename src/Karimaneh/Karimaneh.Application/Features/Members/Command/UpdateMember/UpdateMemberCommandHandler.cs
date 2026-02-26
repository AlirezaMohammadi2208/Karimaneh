using Common.Application.CQRS.Command;
using Common.Application.Exceptions;
using Karimaneh.Domain.MemeberAgg.Repository;
using System.Text.Json;

namespace Karimaneh.Application.Features.Members.Command.UpdateMember
{
    public class UpdateMemberCommandHandler : IBaseCommandHandler<UpdateMemberCommand>
    {
        private readonly IMemberRepository _memberRepository;

        public UpdateMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetMemberById(request.Id);
            if (member == null) throw new NotFoundException("Member", request.Id);

            var oldValue = JsonSerializer.Serialize(member);

            member.Edit(
                request.NationalCode,
                request.FullName,
                request.PhoneNumber,
                request.BankInfo,
                request.MemberStatus,
                request.UserId,
                oldValue);

            await _memberRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
