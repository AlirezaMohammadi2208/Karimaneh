using Karimaneh.Domain.Entities;

namespace Karimaneh.Application.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> GenerateTokenAsync(AppUser user);
    }
}
