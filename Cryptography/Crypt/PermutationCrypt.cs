using System.Collections.Generic;
using System.Text;

namespace Cryptography
{
    public class PermutationCrypt : CryptBase<Dictionary<char, char>>
    {
        public PermutationCrypt(Dictionary<char, char> permutation)
            : base(permutation)
        { }

        public override string Crypt(string text)
        {
            text = text.ToUpper();
            StringBuilder builder = new StringBuilder(text);

            foreach (var keyValue in key)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == keyValue.Key)
                    {
                        builder[i] = keyValue.Value;
                    }
                }
            }

            return builder.ToString();
        }

        public override string Decrypt(string text)
        {
            text = text.ToUpper();
            StringBuilder builder = new StringBuilder(text);

            foreach (var keyValue in key)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == keyValue.Value)
                    {
                        builder[i] = keyValue.Key;
                    }
                }
            }

            return builder.ToString();
        }

        public static Dictionary<char, char> GetKey()
        {
            Dictionary<char, char> key = new Dictionary<char, char>();

            char[] letters = new char[26];

            for (int i = 0; i < 26; i++)
            {
                letters[i] = (char)('A' + i);
            }

            letters.Shuffle();

            for (int i = 0; i < 26; i++)
            {
                key.Add((char)('A' + i), letters[i]);
            }

            return key;
        }
    }
}
