using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{
    //IDK HOW TO SPELL
    public static class Caesar
    {
        public static List<char> alphabet = new List<char>()
        {
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z',
        };

        public static string Encode(string input, int shift)
        {
            ProgressBar bar = new ProgressBar("Caesar Cipher", input.Length);

            string returnValue = "";

            for (int i = 0; i < input.Length; i++)
            {
                bar.Increase();
                if (!alphabet.Contains(input[i].ToLower()))
                {
                    returnValue += input[i];
                    continue;
                }

                int newIndex = alphabet.IndexOf(input[i].ToLower()) + shift;

                while (newIndex >= alphabet.Count)
                {
                    newIndex -= alphabet.Count;
                }

                while (newIndex < 0)
                {
                    newIndex += alphabet.Count;
                }

                returnValue += alphabet[newIndex];
            }

            return returnValue;
        }
    }
}
