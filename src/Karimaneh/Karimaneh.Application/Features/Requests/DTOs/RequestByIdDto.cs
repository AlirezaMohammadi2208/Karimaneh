using Karimaneh.Domain.MemeberAgg;
using Karimaneh.Domain.RequestAgg.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.DTOs
{
    public class RequestByIdDto
    {
        public Guid RequestId { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public string PhoneNumber { get; set; }
        public DebtStatus DebtStatus { get; set; }
        public List<GuarantorDto> Guarantors { get; set; }

    }
    public class GuarantorDto
    {
        public string NationalCode { get; set; }
        public DebtStatus DebtStatus { get; set; }
        public decimal DebtAmount { get; set; }
        //TODO : قسط ها و تعدادشون
    }
}
