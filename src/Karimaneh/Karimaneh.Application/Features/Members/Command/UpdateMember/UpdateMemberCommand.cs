using Common.Application.CQRS.Command;
using Common.Domain.ValueObjects;

namespace Karimaneh.Application.Features.Members.Command.UpdateMember
{
    public class UpdateMemberCommand : IBaseCommand
    {
        public Guid Id { get; set; }
        public NationalCode NationalCode { get; set; }
        public string FullName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public BankInfo BankInfo { get; set; }
        public bool MemberStatus { get; set; }
        public Guid UserId { get; set; }
    }
}
