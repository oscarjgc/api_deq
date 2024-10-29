using System.Text;
using System.Security.Cryptography;

namespace api_DEQ.Utilerias
{
    public static class Utileria
    {
        public static string Creahash(string contrasena)
        {
            SHA512 SHA512 = SHA512.Create();

            byte[] Hash = SHA512.ComputeHash(Encoding.UTF8.GetBytes(contrasena));

            string Hex = BitConverter.ToString(Hash).Replace("-", "");

            return Hex;

        }
    }
}
