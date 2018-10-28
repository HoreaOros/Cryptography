namespace Cryptography
{
    public interface ICrypt
    {
        string Crypt(string text);
        string Decrypt(string text);
    }
}
