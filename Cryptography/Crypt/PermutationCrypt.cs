using System.Collections.Generic;
using System.Linq;
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

            for (int i = 0; i < text.Length; i++)
            {
                if ('A' <= text[i] && text[i] <= 'Z')
                {
                    builder[i] = key[text[i]];
                }
            }

            return builder.ToString();
        }

        public override string Decrypt(string text)
        {
            text = text.ToUpper();
            StringBuilder builder = new StringBuilder(text);

            for (int i = 0; i < text.Length; i++)
            {
                if ('A' <= text[i] && text[i] <= 'Z')
                {
                    builder[i] = key.FirstOrDefault(w => w.Value==text[i]).Key;
                }
            }

            return builder.ToString();
        }

        public static Dictionary<char, char> GetKey()
        {
            Dictionary<char, char> key = new Dictionary<char, char>();

            char[] letters = new char[26];

            for (char i = 'A'; i <= 'Z'; i++)
            {
                letters[i - 'A'] = i;
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
