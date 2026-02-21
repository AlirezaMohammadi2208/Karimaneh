using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.MessageAgg
{
    /// <summary>
    /// پیام
    /// </summary>
    public class Message : BaseEntity , IAggregateRoot
    {
        public Message(Guid memberId, string body, DateTime sendDate, SeenStatus seenStatus)
        {
            MemberId = memberId;
            Body = body;
            SendDate = sendDate;
            SeenStatus = seenStatus;
        }

        private Message() { } //EF 
        public Guid MemberId { get; private set; }
        /// <summary>
        /// بدنه و متن  پیام
        /// </summary>
        public string Body { get; private set; }
        /// <summary>
        /// تاریخ ارسال 
        /// </summary>
        public DateTime SendDate { get; private set; }
        /// <summary>
        /// وضعیت بازدید
        /// </summary>
        public SeenStatus SeenStatus { get; private set; }
    }
    public enum SeenStatus
    {

    }
}
