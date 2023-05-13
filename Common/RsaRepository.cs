using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class RsaRepository : IRsaRepository
    {
        public string Encrypt(string plaintext)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            RSACryptoServiceProvider rsa = new(2048);
            byte[] ciphertext = rsa.Encrypt(plaintextBytes, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(ciphertext);
        }

        public string Decrypt(string ciphertext)
        {
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);
            RSACryptoServiceProvider rsa = new(2048);
            byte[] plaintextBytes = rsa.Decrypt(ciphertextBytes, RSAEncryptionPadding.OaepSHA256);
            return Encoding.UTF8.GetString(plaintextBytes);
        }

        public void GenerateKeys(out string publicKey, out string privateKey)
        {
            using RSACryptoServiceProvider rsa = new(2048);
            publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        }
    }
}

