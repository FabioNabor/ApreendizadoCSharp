using System.Security.Cryptography;
using System.Text;

namespace FTorrent.API.Service
{
    public class GeneryIdentificador
    {
        public static string GenIdentificador(string identificador)
        {
            SHA256 sha = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(identificador);
            byte[] hash = sha.ComputeHash(bytes);
            StringBuilder identify = new StringBuilder();
            foreach (byte b in hash)
            {
                identify.Append(b.ToString("x2"));
            }
            return identify.ToString().Substring(0,15);
        }
    }
}
