
using Karimaneh.Application.Features.RefreshTokens.DTOs;

namespace Karimaneh.Application.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<string> GenerateTokenAsync(Guid userId);
        Task<RefreshTokenDto?> GetTokenAsync(string refreshToken);
        Task RevokeTokenAsync(Guid userId, string reason);
        Task SaveChangesAsync();
    }
}
