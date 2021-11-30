using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class Phonetics
    {
        public static List<string> NATO = new()
        {
            "alfa",
            "bravo",
            "charlie",
            "delta",
            "echo",
            "foxtrot",
            "golf",
            "hotel",
            "india",
            "juliett",
            "kilo",
            "lima",
            "mike",
            "november",
            "oscar",
            "papa",
            "quebec",
            "romeo",
            "sierra",
            "tango",
            "uniform",
            "victor",
            "whiskey",
            "x-ray",
            "yankee",
            "zulu",
        };

        static string GetWordFor(char letter, List<string> phoneticAlphabet)
        {
            letter = letter.ToLower();
            for (int i = 0; i < phoneticAlphabet.Count; i++)
            {
                if (phoneticAlphabet[i][0].ToLower() == letter)
                    return phoneticAlphabet[i];
            }

            return "_ERROR";
        }

        public static string Encode(string input, List<string> phoneticAlphabet, string ProgressBarName)
        {
            if (input.Length == 0)
                return "";

            string returnValue = "";
            ProgressBar bar = new(ProgressBarName, input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                bar.Increase();

                string currentWord = GetWordFor(input[i], phoneticAlphabet);
                if (currentWord == "_ERROR")
                {
                    if (input[i] == '\n' || input[i] == '\r' || input[i] == ' ')
                    {
                        returnValue += " _space";
                        continue;
                    }

                    Program.Error($"{ProgressBarName}: {input[i]} is not a valid character");
                    returnValue += $" !{input[i]}!";
                }
                else
                {
                    returnValue += " " + currentWord;
                }
            }

            return returnValue[1..];
        }

        public static string Decode(string input, string ProgressBarName)
        {
            string[] words = input.Split(' ');

            ProgressBar bar = new(ProgressBarName, words.Length);
            string returnValue = "";

            for (int i = 0; i < words.Length; i++)
            {
                bar.Increase();

                if (words[i] == "")
                    continue;
                else if (words[i] == " _space")
                    returnValue += " ";
                else
                    returnValue += words[i][0];
            }

            return returnValue;
        }
    }
}
