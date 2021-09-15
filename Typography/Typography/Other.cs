using System;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{
    public static class BackwardsText
    {
        public static string Flip(string Input)
        {
            string returnVal = "";
            ProgressBar bar = new ProgressBar("Flip", Input.Length);

            for (int i = Input.Length - 1; i >= 0; i--)
            {
                returnVal += Input[i];

                bar.Increase();
            }

            return returnVal;
        }
    }

    public static class Randomize
    {
        public static string Jumble(string Input)
        {
            ProgressBar bar = new ProgressBar("Randomize", Input.Length);

            List<int> indexesAllowed = new List<int>();

            for (int i = 0; i < Input.Length; i++)
                indexesAllowed.Add(i);

            string returnValue = "";
            Random rng = new Random();

            for (int i = 0; i < Input.Length; i++)
            {
                int newRandomIndex = indexesAllowed[rng.Next(0, indexesAllowed.Count)];
                returnValue += Input[newRandomIndex];
                indexesAllowed.Remove(newRandomIndex);

                bar.Increase();
            }

            return returnValue;
        }
    }

    public static class Append
    {
        public static string Decode(string Input, string append)
        {
            if (Input.Length <= append.Length)
                return "";

            return Input.Substring(0, Input.Length - append.Length);
        }
    }

    public static class SentencePyramid
    {
        public static string sentencePyramid(string Input)
        {
            ProgressBar bar = new ProgressBar("Sentence Pyramid", (Input.Length * 2) - 2);
            List<string> ListFormatreturnVal = new List<string>();
            string returnVal = "";

            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();
                if (i == 0)
                    ListFormatreturnVal.Add(Input[0].ToString());
                else
                    ListFormatreturnVal.Add(ListFormatreturnVal[i - 1] + Input[i]);

                returnVal += ListFormatreturnVal[i] + "\n";
            }

            for (int i = ListFormatreturnVal.Count - 2; i >= 0; i--)
            {
                bar.Increase();
                returnVal += ListFormatreturnVal[i] + "\n";
            }

            return returnVal;
        }
    }

    public static class replaceXwithY
    {
        public static string ReplaceXwithY(string Input, string X, string Y)
        {
            new ProgressBar("Replace", 1, 1).Print();

            if (X.Length == 0 || Y.Length == 0)
            {
                Program.Error($"Cannot replace word with something of zero length");
                return Input;
            }

            return Input.Replace(X, Y);
        }
    }

    public static class sevenSegDisplay
    {
        public static bool SevenSegDisplay(string Input)
        {
            ProgressBar bar = new ProgressBar("7 seg display", 1, 1);
            //letters that cannot be put in 7 seg diplay
            Regex sevenSegDisplay = new Regex("g | k | m | v | w | x | z");

            bar.Print();
            return !sevenSegDisplay.IsMatch(Input);
        }
    }

    public static class longerAndShorter
    {
        public static string Longer(string A, string B)
        {
            return A.Length >= B.Length ? A : B;
        }

        public static string Shorter(string A, string B)
        {
            return A.Length < B.Length ? A : B;
        }

        public static bool EqualTo(string A, string B)
        {
            return A.Length == B.Length;
        }
    }

    public static class expand
    {
        public static string Encode(string Input, uint amount)
        {
            ProgressBar bar = new ProgressBar("Expand (encode)", (int)(Input.Length * amount));
            string returnValue = "";
            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    bar.Increase();
                    returnValue += Input[i];
                }
            }

            return returnValue;
        }

        public static string Decode(string Input, uint amount)
        {
            ProgressBar bar = new ProgressBar("Expand (encode)", (int)(Input.Length / amount));
            string returnValue = "";
            for (int i = 0; i < Input.Length; i += (int)amount)
            {
                bar.Increase();
                returnValue += Input[i];
            }
            return returnValue;
        }
    }

    public static class discordSpoiler
    {
        public static string Encode(string Input)
        {
            ProgressBar bar = new ProgressBar("Discord Spoiler (encode)", Input.Length);

            string returnValue = "";
            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();
                returnValue += $"||{Input[i]}||";
            }

            return returnValue;
        }

        public static string Decode(string Input)
        {
            ProgressBar bar = new ProgressBar("Discord Spoiler (decode)", Input.Length);

            string returnVal = "";
            for (int i = 0; i - 3 < Input.Length; i += 5)
            {
                bar.Increase(5);
                if (i == 0)
                    continue;

                returnVal += Input[i - 3]; //5n-3
            }

            return returnVal;
        }
    }

    public static class BinaryText
    {
        public static string Encode(string input)
        {
            StringBuilder sb = new StringBuilder();
            ProgressBar bar = new("Binary (encode)", input.Length);

            foreach (char c in input.ToCharArray())
            {
                bar.Increase();
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string Decode(string input)
        {
            List<byte> byteList = new List<byte>();
            ProgressBar bar = new("Binary (decode)", input.Length);

            for (int i = 0; i < input.Length; i += 8)
            {
                bar.Increase();
                byteList.Add(Convert.ToByte(input.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }

    public static class Number
    {
        public static string Encode(string input, int NumBase, int padding)
        {
            ProgressBar bar = new ProgressBar("Number (encode)", input.Length);
            StringBuilder sb = new StringBuilder();

            if (NumBase <= 1)
            {
                Program.Error($"Number: base must be above 1 ({NumBase})");
                return input;
            }
            if (padding < 1)
            {
                Program.Error($"Number: padding must be above 0 ({padding})");
                return input;
            }

            foreach (char c in input.ToCharArray())
            {
                bar.Increase();

                sb.Append(Convert.ToString(c, NumBase).PadLeft(padding, '0'));
            }
            return sb.ToString();
        }

        public static string Decode(string input, int NumBase, int padding)
        {
            ProgressBar bar = new ProgressBar("Number (decode)", input.Length);
            List<byte> byteList = new List<byte>();

            for (int i = 0; i < input.Length; i += 8)
            {
                bar.Increase();
                byteList.Add(Convert.ToByte(input.Substring(i, padding), NumBase));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }

    public static class MorseCodeSing
    {
        public static string SingMorseCode(string input, bool Multithreaded)
        {
            if (Multithreaded)
            {
                Thread morsecodethread = new Thread(Sing);
                morsecodethread.Start(input);
                return input;
            }

            Sing(input);
            return input;
        }

        public static void Sing(object Input)
        {
            string morseCode = (string)Input;
            ProgressBar bar = new ProgressBar("Morse code (sing)", morseCode.Length);
            for (int i = 0; i < morseCode.Length; i++)
            {
                bar.Increase();
                if (morseCode[i] == '.')
                {
                    if (!Beep(800, 100))
                        return;
                }

                else if (morseCode[i] == '-')
                {
                    if (!Beep(800, 400))
                        return;
                }

                else if (morseCode[i] == ' ')
                    Thread.Sleep(50);
                else if (morseCode[i] == '/')
                    Thread.Sleep(100);

                else
                    Program.Error($"Morse code: cannot sing character {morseCode[i]}");
            }
        }

        public static bool Beep(int frequency, int duration)
        {
            try
            {
#pragma warning disable
                Console.Beep(frequency, duration);
#pragma warning restore
                return true;
            }
            catch (PlatformNotSupportedException)
            {
                Program.Error("Cannot sing morse code on linux");
                return false;
            }
        }
    }

    public static class capsRandomizer
    {
        public static string Randomize(string Input)
        {
            ProgressBar bar = new ProgressBar("Randomize", Input.Length);
            string returnVal = "";
            Random rng = new Random();

            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();
                bool UpperOrLower = rng.Next(0, 2) == 1;

                returnVal += UpperOrLower ? Input[i].ToUpper() : Input[i].ToLower();
            }

            return returnVal;
        }
    }

    public static class owoify
    {
        static readonly char[] vowels = new char[]
        {
            'a',
            'e',
            'i',
            'o',
            'u'
        };

        public static string Encode(string input)
        {
            ProgressBar bar = new ProgressBar("Owoify", input.Length);
            string returnValue = "";

            for (int i = 0; i < input.Length; i++)
            {
                bar.Increase();

                if (input.Length == 1)
                {
                    returnValue += input[i];
                    break;
                }

                returnValue += input[i];

                if (input[i].ToLower() == 'n' && vowels.Contains(input[i + 1].ToLower()))
                    returnValue += "y";

                else if (input[i] == '!')
                    returnValue += " :3";
            }

            returnValue = returnValue.ToLower().Replace("ove", "uv").Replace("r", "w");

            return returnValue;
        }
    }
}
