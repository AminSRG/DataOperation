using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class RsaService : IRsaService
    {
        protected RSACryptoServiceProvider rSACryptoServiceProvider;
        public RsaService()
        {
            rSACryptoServiceProvider = new RSACryptoServiceProvider(2048);
        }


        public string Encrypt(string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] ciphertext = rSACryptoServiceProvider.Encrypt(plaintextBytes, RSAEncryptionPadding.OaepSHA1);
            return Convert.ToBase64String(ciphertext);
        }

        public string Decrypt(string ciphertext)
        {
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);
            byte[] plaintextBytes = rSACryptoServiceProvider.Decrypt(ciphertextBytes, RSAEncryptionPadding.OaepSHA1);
            return Encoding.UTF8.GetString(plaintextBytes);
        }

    }
}

