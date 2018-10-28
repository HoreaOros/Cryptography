using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cryptography
{
    public class PermutationCryptHack
    {
        Dictionary<char, float> globalAppears;

        public PermutationCryptHack()
        {
            globalAppears = getGlobalAppears();
        }

        private Dictionary<char, float> getGlobalAppears()
        {
            int[] numberOfAppears = new int[26];
            long totalNumber = 0;

            using (StreamReader reader = new StreamReader("../../../Source/globalText.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    line = line.ToUpper();

                    foreach (char letter in line)
                    {
                        if ('A' <= letter && letter <= 'Z')
                        {
                            numberOfAppears[letter - 'A']++;
                            totalNumber++;
                        }
                    }
                }
            }

            Dictionary<char, float> appears = new Dictionary<char, float>();

            for (int i = 0; i < 26; i++)
            {
                var proc = 100 * numberOfAppears[i] / totalNumber;
                appears.Add((char)('A' + i), proc);
            }

            return appears.OrderByDescending(o => o.Value).ToDictionary(t => t.Key, f => f.Value);
        }

        public string Decrypt(string text)
        {
            var localAppears = getLocalAppears(text);

            var letterArrayLocal = new char[26];
            int index = 0;

            foreach (var x in localAppears)
            {
                letterArrayLocal[index] = x.Key;
                index++;
            }

            var letterArrayGlobal = new char[26];
            index = 0;

            foreach (var x in globalAppears)
            {
                letterArrayGlobal[index] = x.Key;
                index++;
            }

            StringBuilder builder = new StringBuilder(text);

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j] == letterArrayLocal[i])
                    {
                        builder[j] = letterArrayGlobal[i];
                    }
                }
            }

            return builder.ToString();
        }

        private Dictionary<char, float> getLocalAppears(string text)
        {
            int[] numberOfAppears = new int[26];
            long totalNumber = 0;

            foreach (char letter in text)
            {
                if ('A' <= letter && letter <= 'Z')
                {
                    numberOfAppears[letter - 65]++;
                    totalNumber++;
                }
            }

            Dictionary<char, float> appears = new Dictionary<char, float>();

            for (int i = 0; i < 26; i++)
            {
                var proc = 100 * numberOfAppears[i] / totalNumber;
                appears.Add((char)('A' + i), proc);
            }

            return appears.OrderByDescending(o => o.Value).ToDictionary(t => t.Key, t => t.Value);
        }
    }
}
