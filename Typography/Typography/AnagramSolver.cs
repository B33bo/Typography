using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class AnagramSolver
    {
        public static string DeAnagram(string anagram)
        {
            List<string> possibleMatches = new();
            for (int i = 0; i < AlphabetAndWords.Words.Count; i++)
            {
                string currWord = AlphabetAndWords.Words[i];

                if (!IsAnagram(currWord, anagram))
                    continue;

                possibleMatches.Add(currWord);
            }

            return possibleMatches.ToRealString(',');
        }

        public static bool IsAnagram(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            a = a.ToLower(); b = b.ToLower();

            char[] ch1 = a.ToLower().ToCharArray();
            char[] ch2 = b.ToLower().ToCharArray();

            Array.Sort(ch1);
            Array.Sort(ch2);

            string val1 = new(ch1);
            string val2 = new(ch2);

            if (val1 == val2)
                return true;

            return false;
        }
    }
}
