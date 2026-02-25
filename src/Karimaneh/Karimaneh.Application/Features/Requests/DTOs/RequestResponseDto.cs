using Karimaneh.Domain.RequestAgg.Enum;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Karimaneh.Application.Features.Requests.DTOs
{
    public class RequestResponseDto
    {
        public Guid RequestId { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public RequestStatus RequestStatus { get; set; }

    }
}
