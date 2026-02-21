using Karimaneh.Domain.Entities;

namespace Karimaneh.Application.Features.RefreshTokens.DTOs
{
    public class RefreshTokenDto
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }
        public string? RevokedReason { get; set; }

        public bool IsExpired => DateTime.Now >= ExpiresAt;
        public bool IsRevoked => RevokedAt != null;
    }
}
