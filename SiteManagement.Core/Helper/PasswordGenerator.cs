using System.Text;

namespace SiteManagement.Core.Helper
{
    public static class PasswordGenerator
    {
        private static readonly string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string NumericChars = "0123456789";
        private static readonly string SpecialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        public static string GeneratePassword(int length, bool useLowercase = true, bool useUppercase = true, bool useNumbers = true, bool useSpecialChars = true)
        {
            StringBuilder charSet = new StringBuilder();
            StringBuilder password = new StringBuilder();

            if (useLowercase) charSet.Append(LowercaseChars);
            if (useUppercase) charSet.Append(UppercaseChars);
            if (useNumbers) charSet.Append(NumericChars);
            if (useSpecialChars) charSet.Append(SpecialChars);

            if (charSet.Length == 0)
            {
                throw new ArgumentException("At least one character set must be selected.");
            }

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int randomSetIndex = random.Next(0, charSet.Length);
                char randomChar = charSet[randomSetIndex];
                password.Append(randomChar);
            }

            return password.ToString();
        }
    }
}
