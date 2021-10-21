using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class WordShift
    {
        public static string ShiftWords(string Input, int Shift)
        {
            ProgressBar bar = new("Word shift", Input.Length);

            Input = Input.ToLower();
            Input = Regex.Replace(Input, @"[^a-zA-Z ]+", "");
            string[] splitByWords = Input.Split(' ');
            string returnValue = "";

            for (int i = 0; i < splitByWords.Length; i++)
            {
                bar.Increase();


                if (!AlphabetAndWords.Words.Contains(splitByWords[i]))
                {
                    returnValue += " " + splitByWords[i];
                    Program.Error($"{splitByWords[i]} is not a word");
                    continue;
                }

                int index = AlphabetAndWords.Words.IndexOf(splitByWords[i]);
                index += Shift;

                while (index >= AlphabetAndWords.Words.Count)
                {
                    index -= AlphabetAndWords.Words.Count;
                }

                while (index < 0)
                {
                    index += AlphabetAndWords.Words.Count;
                }

                returnValue += " " + AlphabetAndWords.Words[index];
            }

            return returnValue[1..];
        }
    }
}
