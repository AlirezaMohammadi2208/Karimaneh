using System.Security.Cryptography;

namespace Karimaneh.Infrastructure.Security
{
    public class SecureTokenGenerator
    {
        public static string GenerateSecureToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
