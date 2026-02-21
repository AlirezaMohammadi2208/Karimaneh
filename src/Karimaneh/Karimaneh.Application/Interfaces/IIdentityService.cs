using Karimaneh.Application.Features.Identities.DTOs;
using Karimaneh.Domain.Entities;
using System.Security.Claims;

namespace Karimaneh.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<(string AccessToken, string RefreshToken)> LoginAsync(LoginRequestDto input);
        Task RegisterAsync(RegisterRequestDto input);
        Task LogoutAsync(Guid userId);
        Task<AppUser> GetUserAsync(ClaimsPrincipal userPrincipal);
        Task<(string AccessToken, string RefreshToken)> RefreshTokenAsync(string refreshToken);

    }
}
