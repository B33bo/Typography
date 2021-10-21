using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class British
    {
        public static Dictionary<string, string> dialectAndWords = new()
        {
            {"man", "bloke"},
            {"boy", "lad"},
            {"crazy", "bonkers"},
            {"mad", "bonkers"},
            {"silly", "daft"},
            {"run", "leg it"},
            {"drunk", "plastered"},
            {"quid", "squid"},
            {"pound", "quid"},
            {"ske'chy", "dodgy"},
            {"sus", "dodgy"},
            {"suspicous", "dodgy"},
            {"rubbish", "pants"},
            {"suprised", "gobsmacked"},
            {"tired", "knackered"},
            {"deenergized", "knackered"},
            {"de-energized", "knackered"},
            {"ma'e", "guv'na"},
            {"gone insane", "lost the plot"},
            {"tea", "cuppa tea"},
            {"fucking", "bloody"},
            {"can't be bothered", "can't be arsed"},
            {"can' be bothered", "can't be arsed"},
            {"'appy", "chuffed"},
            {"poor", "skint"},
            {"broke", "skint"},
            {"£5", "fiver"},
            {"5 pounds", "fiver"},
            {"£10", "tenner"},
            {"10 pounds", "tenner"},
            {"toilet", "bog"},
            {"toilet paper", "bog roll"},
            {"idiot", "git"},
            {"sneaky", "cheeky"},
            {"insult", "slag"},
            {"dumbass", "muppet"},
            {"underwear", "pants"},
            {"pan's", "trousers"},
            {"upset", "gutted"},
            {"oh my god", "blimey"},
            {"mess up", "cock up"},
            {"gross", "minging"},
            {"very", "proper"},
            {"messing around", "faffing around"},
            {"messing about", "faffing about"},
            {"tuesday", "choosday" },
            {"s'u", "schew"},
            {"isn't it", "innit"},
            {"isnt it", "innit"},
            {"don't ya think?", "innit"},
            {"dont ya think?", "innit"},
            {"bri'ish people", "bri'ish \"people\""},
            {"tha''s a", ""},
            {"because", "cuz"},
            {"hey", "oi"},
            {"of", "o'"},
            {"tu", "chew"},
            {"thr", "fr"},
            {"did", "d" },
            {"you", "ya" },
            {"ma'h", "maths"},
            {"walmart", "ASDA" },
            {"target", "Tesco" },
        };

        public static string Encode(string Input)
        {
            Input = Input.ToLower();
            List<string> splitByWords = Input.Split(' ').ToList();
            string returnValue = "";

            if (Input.Length <= 1)
                return Input;

            ProgressBar bar = new("Bri'ish (Encode)", splitByWords.Count + dialectAndWords.Count);

            for (int i = 0; i < splitByWords.Count; i++)
            {
                if (splitByWords[i].Length <= 1)
                    continue;

                if (splitByWords[i].StartsWith("h"))
                    splitByWords[i] = "'" + splitByWords[i][1..];

                if (splitByWords[i].EndsWith("ng"))
                    splitByWords[i] = splitByWords[i][0..^1] + "'";

                char firstChar = splitByWords[i][0];
                char lastChar = splitByWords[i][^1];

                string middleChars = splitByWords[i][1..^1];

                splitByWords[i] = firstChar + middleChars.Replace("t", "'") + lastChar;

                bar.Increase();
            }

            string[] keys = dialectAndWords.Keys.OfType<string>().ToArray();
            returnValue = splitByWords.ToRealString(' ');

            for (int i = 0; i < keys.Length; i++)
            {
                while (splitByWords.Contains(keys[i]))
                {
                    int index = splitByWords.IndexOf(keys[i]);
                    splitByWords[index] = dialectAndWords[keys[i]];
                }

                bar.Increase();
            }

            return splitByWords.ToRealString(' ');
        }

        public static string Decode(string input)
        {
            Dictionary<string, string> reversedSlang = dialectAndWords.FlipDict();
            string returnValue = input;
            string[] keys = reversedSlang.Keys.OfType<string>().ToArray();

            ProgressBar bar = new("Bri'ish (Decode)", keys.Length + input.Count(f => f == ' '));

            List<string> splitByWords = returnValue.Split(' ').ToList();

            for (int i = 0; i < keys.Length; i++)
            {
                bar.Increase();

                while (splitByWords.Contains(keys[i]))
                {
                    int index = splitByWords.IndexOf(keys[i]);
                    splitByWords[index] = reversedSlang[keys[i]];
                }
            }

            for (int i = 0; i < splitByWords.Count; i++)
            {
                string currentWord = splitByWords[i];
                if (currentWord.Length < 2)
                {
                    returnValue += splitByWords[i];
                    continue;
                }

                bar.Increase();

                if (currentWord.StartsWith("'"))
                    currentWord = "h" + currentWord[1..];

                if (currentWord.EndsWith("n'"))
                    currentWord = currentWord[0..^1] + "g";


                if (currentWord.Length > 3)
                {
                    char firstChar = currentWord[0];
                    char lastChar = currentWord[^1];
                    string middleChars = currentWord[1..^1];

                    currentWord = firstChar + middleChars.Replace("'", "t") + lastChar;
                }

                splitByWords[i] = currentWord;
            }

            return splitByWords.ToRealString(' ');
        }
    }
}
