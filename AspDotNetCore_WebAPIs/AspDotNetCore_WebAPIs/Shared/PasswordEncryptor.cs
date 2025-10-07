using System.Security.Cryptography;
using System.Text;

namespace AspDotNetCore_WebAPIs.Shared
{
    public static class PasswordEncryptor
    {
        public static void CreatePasswordHashandSalt(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPasswordhashandsalt(string password, byte[] Storedhash, byte[] Storedsalt)
        {
            using var hmac = new HMACSHA512(Storedsalt);
            var computehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computehash.SequenceEqual(Storedhash);
        }
    }
}
