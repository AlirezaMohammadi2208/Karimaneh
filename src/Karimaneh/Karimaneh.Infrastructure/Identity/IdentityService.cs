using Common.Application.Exceptions;
using FluentValidation;
using Karimaneh.Application.Features.Identities.DTOs;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Karimaneh.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<IdentityService> _logger;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IValidator<LoginRequestDto> _validator;
        private readonly IValidator<RegisterRequestDto> _registerValidator;

        public IdentityService(UserManager<AppUser> userManager, ILogger<IdentityService> logger, IJwtTokenService jwtTokenService, IRefreshTokenService refreshTokenService, IValidator<LoginRequestDto> validator, IValidator<RegisterRequestDto> registerValidator)
        {
            _userManager = userManager;
            _logger = logger;
            _jwtTokenService = jwtTokenService;
            _refreshTokenService = refreshTokenService;
            _validator = validator;
            _registerValidator = registerValidator;
        }

        public async Task<(string AccessToken, string RefreshToken)> LoginAsync(LoginRequestDto input)
        {
            await _validator.ValidateAndThrowAsync(input);
            var user = await _userManager.FindByNameAsync(input.Username);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password");

            var validPassword = await _userManager.CheckPasswordAsync(user, input.Password);
            if (!validPassword)
                throw new UnauthorizedAccessException("Invalid username or password");

            _logger.LogInformation("User logged in successfully.");

            var accessToken = await _jwtTokenService.GenerateTokenAsync(user);
            var refreshToken = await _refreshTokenService.GenerateTokenAsync(user.Id);
            return (accessToken, refreshToken);
        }

        public async Task RegisterAsync(RegisterRequestDto input)
        {
            await _registerValidator.ValidateAndThrowAsync(input);
            var user = new AppUser
            {
                UserName = input.Username,
                MemberId = input.MemberId
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }

            _logger.LogInformation("User registered successfully.");
        }

        public async Task LogoutAsync(Guid userId)
        {
            await _refreshTokenService.RevokeTokenAsync(userId, "Logout");
            await _refreshTokenService.SaveChangesAsync();
            _logger.LogInformation("User logged out successfully.");
        }

        public async Task<AppUser> GetUserAsync(ClaimsPrincipal userPrincipal)
        {
            if (userPrincipal == null)
                throw new ArgumentNullException(nameof(userPrincipal));

            var user = await _userManager.GetUserAsync(userPrincipal);
            if (user == null)
                //throw new BadHttpRequestException("Invalid Request");
                throw new NotFoundException("Invalid Request");

            return user;
        }

        public async Task<(string AccessToken, string RefreshToken)> RefreshTokenAsync(string refreshToken)
        {
            var token = await _refreshTokenService.GetTokenAsync(refreshToken);

            if (token == null || token.IsExpired || token.IsRevoked)
                throw new UnauthorizedAccessException("Invalid refresh token");

            token.RevokedAt = DateTime.Now;
            token.RevokedReason = "Rotated";
            await _refreshTokenService.SaveChangesAsync();

            var newRefreshToken = await _refreshTokenService.GenerateTokenAsync(token.UserId);
            var newAccessToken = await _jwtTokenService.GenerateTokenAsync(token.User);

            return (newAccessToken, newRefreshToken);
        }
    }
}
