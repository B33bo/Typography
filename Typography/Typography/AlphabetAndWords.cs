using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Typography.Meta;
using System.Threading.Tasks;

namespace Typography
{
    public static class AlphabetAndWords
    {
        public static char[] alphabet = new char[]
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

        public static List<char> punctuation = new()
        {
            '!',
            '.',
            '?',
            '(',
            ')',
        };

        private static List<string> words = new();

        public static List<string> Words
        {
            get
            {
                if (words.Count == 0)
                    words = File.ReadAllLines(TypographyExtention.GetPathFromPartial("Words.txt")).ToList();

                return words;
            }
        }

        public static string[] vowels = new string[] { "a", "e", "i", "o", "u", "y" };
        public static string[] consonants = new string[] { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    }
}