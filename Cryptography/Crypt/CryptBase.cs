namespace Cryptography
{
    public abstract class CryptBase<T> : ICrypt
    {
        protected T key;

        public CryptBase(T key)
        {
            this.key = key;
        }

        public abstract string Crypt(string text);

        public abstract string Decrypt(string text);
    }
}
