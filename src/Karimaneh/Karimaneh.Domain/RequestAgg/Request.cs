using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using Karimaneh.Domain.RequestAgg.Enum;
using Karimaneh.Domain.RequestAgg.Events;

namespace Karimaneh.Domain.RequestAgg
{
    /// <summary>
    /// درخواست
    /// </summary>
    public class Request : BaseEntity, IAggregateRoot
    {
        private Request() { } //EF

        private Request(Guid memberId, decimal amount,
             string description)
        {
            ValueGuard(amount, description);
            MemberId = memberId;
            Amount = amount;

            Description = description;

        }

        public Guid MemberId { get; private set; }
        /// <summary>
        /// مبلغ درخواستی
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// تایم درخواست 
        /// </summary>
        public DateTime RequestDate { get; private set; } = DateTime.Now;
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
        public RequestStatus RequestStatus { get; private set; } = RequestStatus.Pending;
        private readonly List<Guarantor> _guarantors = new();
        public IReadOnlyCollection<Guarantor> Guarantors => _guarantors;

        public static Request Create(Guid memberId, decimal amount,
             string description, Guid userId)
        {
            var request = new Request(memberId, amount
                , description);
            request.AddDomainEvent(new RequestCreatedEvent(request, userId));
            return request;
        }
        public void AddGuarantors(List<Guarantor> guarantors)
        {
            _guarantors.AddRange(guarantors);
        }
        public void Confirm()
        {
            RequestStatus = RequestStatus.Confirmed;
        }
        public void Reject()
        {
            RequestStatus = RequestStatus.Rejected;
        }



        #region Validation
        private void ValueGuard(decimal amount, string description)
        {
            if (amount <= 0)
                throw new DomainException("مبلغ درخواستی وام نمیتواند کمتر از صفر باشد");
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("علت درخواست وام نمیتواند خالی باشد");
        }
        #endregion 
    }
}
