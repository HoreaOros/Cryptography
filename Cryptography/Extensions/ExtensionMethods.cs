using System;

namespace Cryptography
{
    public static class ExtensionMethods
    {
        static Random _random = new Random();

        public static char GetShiftedLetter(this char currentLetter, int shiftValue)
        {
            int AIndex = (int)'A';
            int lettersNumber = 26;

            shiftValue = shiftValue % lettersNumber;

            int currentLetterValue = (int)currentLetter;

            var shiftedLetterValue = (currentLetterValue + shiftValue - AIndex) % lettersNumber + AIndex;

            return (char)shiftedLetterValue;
        }

        public static void Shuffle<T>(this T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + _random.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
    }
}
