namespace Common
{
    public interface IRsaService
    {
        string Encrypt(string plaintext);
        string Decrypt(string ciphertext);
        public void GenerateKeys(out string publicKey, out string privateKey);
    }
}

