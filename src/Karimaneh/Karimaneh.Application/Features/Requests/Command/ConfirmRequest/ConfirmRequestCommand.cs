using Common.Application.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.Command.ConfirmRequest
{
    public class ConfirmRequestCommand : IBaseCommand
    {
        public Guid RequestId { get; set; }
        public DateOnly StartDate { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentCount { get; set; }
        public Guid UserId { get; set; }
    }
}
