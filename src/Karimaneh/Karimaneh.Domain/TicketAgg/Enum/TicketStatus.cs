using System.ComponentModel.DataAnnotations;

namespace Karimaneh.Domain.TicketAgg.Enum
{
    public enum TicketStatus
    {
        [Display(Name = "تایید شده")]
        Approved,
        [Display(Name = "نیاز به اصلاح")]
        NeedsCorrection,
        [Display(Name = "در انتظار بررسی")]
        Pending
    }
}
