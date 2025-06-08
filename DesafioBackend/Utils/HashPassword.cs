using System.Security.Cryptography;
using System.Text;
using DesafioBackend.Interfaces;

namespace DesafioBackend.Utils
{
    public class HashPassword:IHashPassword
    {
        private readonly IConfiguration _configuration;

        public HashPassword(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string encryptSHA256(string text) {
            using (SHA256 sha256Hash = SHA256.Create()) { 
            
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) { 
                    builder.Append(bytes[i].ToString("X2"));   
                }
            return builder.ToString();
            }
            
        }



    }
}
