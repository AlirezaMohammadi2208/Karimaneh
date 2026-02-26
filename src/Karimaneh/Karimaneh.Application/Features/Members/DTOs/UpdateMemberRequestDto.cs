using Common.Domain.ValueObjects;

namespace Karimaneh.Application.Features.Members.DTOs
{
    public class UpdateMemberRequestDto
    {
        public Guid Id { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public BankInfo BankInfo { get; set; }
        public bool MemberStatus { get; set; }
    }
}
