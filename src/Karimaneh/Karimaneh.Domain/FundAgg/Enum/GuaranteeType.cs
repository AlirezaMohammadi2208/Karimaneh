using System.ComponentModel.DataAnnotations;

namespace Karimaneh.Domain.FundAgg.Enum
{
    public enum GuaranteeType
    {
        [Display(Name = "چک")]
        Check,
        [Display(Name = "سفته")]
        PromissoryNote,
        [Display(Name = "بدون ضامن")]
        None
    }
}
