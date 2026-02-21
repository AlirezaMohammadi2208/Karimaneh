using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.TicketAgg
{
    /// <summary>
    /// تیکت
    /// </summary>
    public class Ticket : BaseEntity , IAggregateRoot
    {
        public Ticket(string subject, string body, Priority priority,
            Guid memberId, DateTime sendDate, TicketStatus ticketStatus,
            string? responseBody)
        {
            Subject = subject;
            Body = body;
            Priority = priority;
            MemberId = memberId;
            SendDate = sendDate;
            TicketStatus = ticketStatus;
            ResponseBody = responseBody;
        }

        private Ticket() { } //EF
        /// <summary>
        /// موضوع 
        /// </summary>
        public string Subject { get; private set; }
        /// <summary>
        /// متن و بدنه تیکت
        /// </summary>
        public string Body { get; private set; }
        /// <summary>
        /// اولویت
        /// </summary>
        public Priority Priority { get; private set; }
        public Guid MemberId { get; private set; }
        /// <summary>
        /// تاریخ ارسال 
        /// </summary>
        public DateTime SendDate { get; private set; }
        /// <summary>
        /// وضعیت تیکت
        /// </summary>
        public TicketStatus TicketStatus { get; private set; }
        /// <summary>
        /// پاسخ تیکت
        /// </summary>
        public string? ResponseBody { get; private set; }
    }
    public enum Priority
    {

    }
    public enum TicketStatus
    {

    }
}
