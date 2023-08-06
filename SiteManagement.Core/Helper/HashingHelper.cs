using System.Text;
using System.Security.Cryptography;

namespace SiteManagement.Core.Helper
{
    public class HashingHelper
    {
        public static string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[size];

            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        public static string CreatePasswordHash(string pwd, string salt)
        {
            var data = Encoding.ASCII.GetBytes(String.Concat(pwd, salt));

            var hashData = new SHA1Managed().ComputeHash(data);

            var hash = string.Empty;

            foreach (var b in hashData)
            {
                hash += b.ToString("X2");
            }

            return hash;
        }

      
        public static string GetChecksum(string sentence)
        {
            var md5 = MD5.Create();

            var sb = new StringBuilder();

            using (var fs = new MemoryStream(Encoding.UTF8.GetBytes(sentence)))
            {
                foreach (byte b in md5.ComputeHash(fs))
                {
                    sb.Append(b.ToString("x2").ToLower());
                }
            }

            return sb.ToString();
        }
    }
}
