using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.RequestAgg
{
    /// <summary>
    /// درخواست
    /// </summary>
    public class Request : BaseEntity, IAggregateRoot
    {
        private Request() { } //EF

        public Request(Guid memberId, decimal amount, DateTime requestDate,
            DateTime? confirmDate, string description, RequestStatus requestStatus)
        {
            MemberId = memberId;
            Amount = amount;
            RequestDate = requestDate;
            ConfirmDate = confirmDate;
            Description = description;
            RequestStatus = requestStatus;
        }

        public Guid MemberId { get; private set; }
        /// <summary>
        /// مبلغ درخواستی
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// تایم درخواست 
        /// </summary>
        public DateTime RequestDate { get; private set; }
        /// <summary>
        /// تاریخ تایید 
        /// </summary>
        public DateTime? ConfirmDate { get; private set; }
        /// <summary>
        /// علت درخواست وام
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// وضعیت درخواست
        /// </summary>
        public RequestStatus RequestStatus { get; private set; }
        private readonly List<Guarantor> _guarantors = new();
        public IReadOnlyCollection<Guarantor> Guarantors => _guarantors;
    }
    public enum RequestStatus
    {

    }
}
