using Ardalis.GuardClauses;
using Common.Domain.BaseModels;

namespace Karimaneh.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public RefreshToken(string token, Guid userId, DateTime expiresAt)
        {
            Guard.Against.NullOrEmpty(token, nameof(token));
            Guard.Against.NullOrEmpty(userId, nameof(userId));
            Guard.Against.NullOrOutOfSQLDateRange(expiresAt, nameof(expiresAt));

            Token = token;
            UserId = userId;
            ExpiresAt = expiresAt;
        }

#pragma warning disable CS8618 // Required by Entity Framework
        private RefreshToken() { }

        public string Token { get; private set; } = null!;
        public Guid UserId { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public string? RevokedReason { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public AppUser User { get; private set; } = null!;
        public bool IsExpired => DateTime.Now >= ExpiresAt;
        public bool IsRevoked => RevokedAt != null;

        public void Revoke(DateTime revokedAt, string revokedReason)
        {
            Guard.Against.NullOrEmpty(revokedReason, nameof(revokedReason));

            RevokedAt = revokedAt;
            RevokedReason = revokedReason;
        }
    }
}
