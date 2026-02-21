using Common.Domain.BaseModels;

namespace Karimaneh.Domain.RequestAgg
{
    /// <summary>
    /// گارانتی
    /// </summary>
    public class Guarantor : BaseEntity
    {
        public Guid MemeberId { get; private set; }
        public Guid RequestId { get; private set; }
        /// <summary>
        /// وضعیت تاییدیه ضامن
        /// </summary>
        public bool IsAccept { get; private set; }
    }
}
