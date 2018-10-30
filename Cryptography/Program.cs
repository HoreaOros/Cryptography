using System;
using System.IO;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            ICrypt caesarCrypt = new CaesarCrypt();

            var text = "ANA ARE MERE MULTE SI FRUMOASE, AZOREL FURA MERELE";

            var cryptedText = caesarCrypt.Crypt(text);

            var decryptedText = caesarCrypt.Decrypt(cryptedText);

            ICrypt caesarCryptN = new CaesarCrypt(10);

            var textN = "Si acest algoritm de criptare functioneaza";

            var cryptedTextN = caesarCryptN.Crypt(textN);

            var decryptedTextN = caesarCryptN.Decrypt(cryptedTextN);

            ICrypt root13 = new Rot13();

            var textR = "SI ROOT 13 FUNCTIONEAZA";

            var cryptedTextR = root13.Crypt(textR);

            var decryptedTextR = root13.Decrypt(cryptedTextR);

            var permutation = PermutationCrypt.GetKey();

            ICrypt permutationCrypt = new PermutationCrypt(permutation);

            var textPerm = File.ReadAllText("../../../Source/localText.txt");

            var cryptedTextPerm = permutationCrypt.Crypt(textPerm);

            var decryptedTextPerm = permutationCrypt.Decrypt(cryptedTextPerm);

            PermutationCryptHack hack=new PermutationCryptHack();

            var hackDecrypt=hack.Decrypt(cryptedTextPerm);

            Console.ReadKey();
        }
    }
}
