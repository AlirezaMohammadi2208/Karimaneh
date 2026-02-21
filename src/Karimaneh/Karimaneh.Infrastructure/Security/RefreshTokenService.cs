using AutoMapper;
using Karimaneh.Application.Features.RefreshTokens.DTOs;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Karimaneh.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Karimaneh.Infrastructure.Security
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly AppIdentityDbContext _context;
        private readonly IMapper _mapper;

        public RefreshTokenService(AppIdentityDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> GenerateTokenAsync(Guid userId)
        {

            await RevokeTokenAsync(userId, "New Login");

            var refreshToken = new RefreshToken(
                SecureTokenGenerator.GenerateSecureToken(),
                userId,
                DateTime.Now.AddDays(30));

            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();
            return refreshToken.Token;
        }
        public async Task<RefreshTokenDto?> GetTokenAsync(string refreshToken)
        {
            var result = await _context.RefreshTokens
          .Include(x => x.User)
          .FirstOrDefaultAsync(x => x.Token == refreshToken);
            return _mapper.Map<RefreshTokenDto>(result);
        }
        public async Task<IEnumerable<RefreshToken>> GetActiveTokenAsync(Guid userId)
        {
            return await _context.RefreshTokens
           .Where(x => x.UserId == userId && x.RevokedAt == null)
           .ToListAsync();
        }
        public async Task RevokeTokenAsync(Guid userId, string reason)
        {
            var tokens = await GetActiveTokenAsync(userId);

            foreach (var token in tokens)
            {
                token.Revoke(DateTime.Now, reason);
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
