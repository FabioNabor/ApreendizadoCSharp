using System.Security.Cryptography;
using System.Text;

namespace FTorrent.API.Service
{
    public class HashPassword
    {
        public static string CodPassword(string password)
        {

			SHA256 baseHash = SHA256.Create();

			byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = baseHash.ComputeHash(bytes);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();

        }
    }
}
