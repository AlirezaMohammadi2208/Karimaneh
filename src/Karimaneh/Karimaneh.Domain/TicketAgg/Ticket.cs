using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Karimaneh.Domain.TicketAgg.Enum;
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
            Guid memberId)
        {
            ValueGuard(subject , body);
            Subject = subject;
            Body = body;
            Priority = priority;
            MemberId = memberId;
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
        public DateTime SendDate { get; private set; } = DateTime.UtcNow;
        /// <summary>
        /// وضعیت تیکت
        /// </summary>
        public TicketStatus TicketStatus { get; private set; } = TicketStatus.Pending;
        /// <summary>
        /// پاسخ تیکت
        /// </summary>
        public string? ResponseBody { get; private set; }

        //public static Ticket Create()
        //{

        //}
        #region Vallidation
        private void ValueGuard(string subject , string body )
        {
            if (string.IsNullOrWhiteSpace(subject))
                throw new DomainException("موضوع تیکت نمیتواند خالی باشد");
            if (string.IsNullOrWhiteSpace(body))
                throw new DomainException("پیام تیکت نمیتواند خالی باشد");
        }
        #endregion
    }
}
