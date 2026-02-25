using Common.Domain.BaseModels;

namespace Karimaneh.Domain.RequestAgg
{
    /// <summary>
    /// گارانتی
    /// </summary>
    public class Guarantor : BaseEntity
    {
        private Guarantor(Guid memeberId, Guid requestId)
        {
            MemeberId = memeberId;
            RequestId = requestId;
            
        }

        private Guarantor() { } //EF
        
        
        public Guid MemeberId { get; private set; }
        public Guid RequestId { get; private set; }
        /// <summary>
        /// وضعیت تاییدیه ضامن
        /// </summary>
        public bool IsAccept { get; private set; } = false;

        public static Guarantor Create(Guid memeberId, Guid requestId)
        {
            var guarantor = new Guarantor(memeberId , requestId);
            
            return guarantor;
        }
    }
}
