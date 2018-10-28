using System;
using System.Text;

namespace Cryptography
{
    public class CaesarCrypt : CryptBase<int>
    {
        public CaesarCrypt(int key = 3)
            : base(key)
        {
            this.key = key;
        }

        public override string Crypt(string text)
        {
            StringBuilder textBuilder = new StringBuilder(text.ToUpper());

            for (int i = 0; i < textBuilder.Length; i++)
            {
                if (Char.IsLetter(textBuilder[i]))
                {
                    textBuilder[i] = textBuilder[i].GetShiftedLetter(key);
                }
            }

            return textBuilder.ToString();
        }

        public override string Decrypt(string text)
        {
            StringBuilder textBuilder = new StringBuilder(text.ToUpper());

            for (int i = 0; i < textBuilder.Length; i++)
            {
                if (Char.IsLetter(textBuilder[i]))
                {
                    textBuilder[i] = textBuilder[i].GetShiftedLetter(26 - key);
                }
            }

            return textBuilder.ToString();
        }
    }
}
