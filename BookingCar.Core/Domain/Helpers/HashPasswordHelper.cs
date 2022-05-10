using System.Web.Helpers;

namespace BookingCar.Core.Domain.Helpers
{
    public static class HashPasswordHelper
    {
        public static string HashPassword(this string password)
        {
            var hashPass = Crypto.HashPassword(password);
            return hashPass;
        }

        public static bool Verification(this string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
