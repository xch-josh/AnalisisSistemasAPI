using System.Text;
using System.Security.Cryptography;

namespace AnalisisSistemasAPI.Utils
{
    public class Encrypt
    {
        public string EncryptPass(string pass)
        {
            SHA256 encrypt = SHA256.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();

            stream = encrypt.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++)
                sb.AppendFormat("{0:x2}", stream[i]);

            return sb.ToString();
        }
    }
}
