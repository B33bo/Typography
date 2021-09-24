using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{

    public static class AlphabetAndWords
    {
        public static List<char> alphabet = new()
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
    }
}