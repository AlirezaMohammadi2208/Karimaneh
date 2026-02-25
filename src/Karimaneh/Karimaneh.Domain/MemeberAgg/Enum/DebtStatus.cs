using System.ComponentModel.DataAnnotations;

namespace Karimaneh.Domain.MemeberAgg
{
    public enum DebtStatus
    {
        [Display(Name ="دارد")]
        Have,
        [Display(Name = "ندارد")]
        NotHave
    }
}
