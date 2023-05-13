namespace Common
{
    public interface IRsaRepository
    {
        string Encrypt(string plaintext);
        string Decrypt(string ciphertext);
        public void GenerateKeys(out string publicKey, out string privateKey);
    }
}

