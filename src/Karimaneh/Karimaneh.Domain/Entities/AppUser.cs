using Microsoft.AspNetCore.Identity;

namespace Karimaneh.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public Guid MemberId { get; set; }
    }
}
