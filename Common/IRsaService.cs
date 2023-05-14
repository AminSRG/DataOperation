namespace Common
{
    public interface IRsaService
    {
        string Encrypt(string plaintext);
        string Decrypt(string ciphertext);
    }
}

