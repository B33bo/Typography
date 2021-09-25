using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{
    public class BadSpelling
    {
        public static Dictionary<string, string> Mistakes = new()
        {
            {"ba", "ab"},
            {"ve", "e"},
            {" is ", "iz"},
            {"oo", "o"},
            {"ome", "um"},
            {"ate", "8"},
            {" could ", "cood"},
            {"you", "u"},
            {"come", "cum"},
            {"4", "for"},
            {"the", "da"},
            {"tr", "chr"},
            {"was", "woz"},
            {"an", "am"},
            {"tion", "shun"},
            {"ck", "k" },
            {"school", "skool" },
            {"ight", "ite" },
        };

        public static string Encode(string Input)
        {
            Input = Input.ToLower();

            if (Input.Length <= 1)
                return Input;

            int spaceKeys = Input.ToCharArray().Count(c => c == ' ');
            ProgressBar bar = new("Speling mistake (Encode)", spaceKeys + Input.Length + Mistakes.Count);

            string returnValue = "";

            //remove repeating leters
            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();

                if (i == 0)
                {
                    returnValue += Input[i];
                    continue;
                }

                if (Input[i - 1] == Input[i])
                    continue;

                returnValue += Input[i];
            }

            List<string> splitByWords = returnValue.Split(' ').ToList();

            for (int i = 0; i < splitByWords.Count; i++)
            {
                bar.Increase();

                if (splitByWords[i].Length <= 1)
                    continue;

                if (splitByWords[i].EndsWith("s"))
                    splitByWords[i] = splitByWords[i][0..^1] + "z";
            }

            string[] keys = Mistakes.Keys.OfType<string>().ToArray();
            returnValue = splitByWords.ToRealString(' ');

            for (int i = 0; i < keys.Length; i++)
            {
                while (splitByWords.Contains(keys[i]))
                {
                    int index = splitByWords.IndexOf(keys[i]);
                    splitByWords[index] = Mistakes[keys[i]];
                }

                bar.Increase();
            }

            return splitByWords.ToRealString(' ');
        }
    }
}