using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.DTOs
{
    public class SetConfirmAppReqRequest
    {
        public DateOnly StartDate { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentCount { get; set; }
    }
}
