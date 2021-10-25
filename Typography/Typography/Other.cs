using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class BackwardsText
    {
        public static string Flip(string Input)
        {
            string returnVal = "";
            ProgressBar bar = new("Flip", Input.Length);

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
            ProgressBar bar = new("Anagram", Input.Length);

            List<int> indexesAllowed = new ();

            for (int i = 0; i < Input.Length; i++)
                indexesAllowed.Add(i);

            string returnValue = "";
            Random rng = new();

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
        public static string Encode(string Input)
        {
            ProgressBar bar = new("Sentence Pyramid", (Input.Length * 3) - 2);
            List<string> ListFormatreturnVal = new();
            string returnVal = "";

            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();

                if (i == 0)
                    ListFormatreturnVal.Add(Input[0].ToString());
                else
                    ListFormatreturnVal.Add(ListFormatreturnVal[^1] + Input[i]);
            }

            for (int i = 0; i < ListFormatreturnVal.Count; i++)
            {
                if (ListFormatreturnVal[i].EndsWith(" "))
                {
                    ListFormatreturnVal.RemoveAt(i);
                    i = 0;
                }
            }

            returnVal = ListFormatreturnVal.ToRealString('\n') + "\n";

            for (int i = ListFormatreturnVal.Count - 2; i >= 0; i--)
            {
                bar.Increase();
                returnVal += ListFormatreturnVal[i] + "\n";
            }

            return returnVal;
        }
    }

    public static class ReplaceXwithY
    {
        public static string Encode(string Input, string X, string Y)
        {
            new ProgressBar("Replace", 1, 1).Print();

            if (X.Length == 0)
            {
                Program.Error($"Cannot replace word with something of zero length");
                return Input;
            }

            return Input.Replace(X, Y);
        }
    }

    public static class SevenSegDisplay
    {
        public static bool Encode(string Input)
        {
            ProgressBar bar = new("7 seg display", 1, 1);
            //letters that cannot be put in 7 seg diplay
            Regex sevenSegDisplay = new("g | k | m | v | w | x | z");

            bar.Print();
            return !sevenSegDisplay.IsMatch(Input);
        }
    }

    public static class LongerAndShorter
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

    public static class Expand
    {
        public static string Encode(string Input, uint amount)
        {
            ProgressBar bar = new("Expand (encode)", (int)(Input.Length * amount));
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
            ProgressBar bar = new("Expand (encode)", (int)(Input.Length / amount));
            string returnValue = "";
            for (int i = 0; i < Input.Length; i += (int)amount)
            {
                bar.Increase();
                returnValue += Input[i];
            }
            return returnValue;
        }
    }

    public static class DiscordSpoiler
    {
        public static string Encode(string Input)
        {
            ProgressBar bar = new("Discord Spoiler (encode)", Input.Length);

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
            ProgressBar bar = new ("Discord Spoiler (decode)", Input.Length);

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
            StringBuilder sb = new ();
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
            List<byte> byteList = new();
            ProgressBar bar = new("Binary (decode)", input.Length);

            input = input.Replace(" ", "");

            for (int i = 0; i < input.Length; i += 8)
            {
                bar.Increase();

                try
                {
                    byteList.Add(Convert.ToByte(input.Substring(i, 8), 2));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Program.Error($"{input} is not a valid binary");
                }
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }

    public static class Number
    {
        public static int[] bases = new int[] { 2, 8, 10, 16 };
        public static string Encode(string input, int NumBase, int padding)
        {
            ProgressBar bar = new("Number (encode)", input.Length);
            StringBuilder sb = new();

            if (!bases.Contains(NumBase))
            {
                Program.Error($"Number: base must be 2,4,8,16 ({NumBase})");
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
            input = input.Replace(" ", "");
            ProgressBar bar = new ("Number (decode)", input.Length);
            List<byte> byteList = new();

            if (!bases.Contains(NumBase))
            {
                Program.Error($"Number: base must be 2,4,8,16 ({NumBase})");
                return input;
            }

            for (int i = 0; i < input.Length; i += 8)
            {
                bar.Increase();
                byteList.Add(Convert.ToByte(input.Substring(i, padding), NumBase));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public static int DecodeNum(string input, int NumBase)
        {
            return Convert.ToInt32(input, NumBase);
        }

        public static string EncodeNum(string input, int NumBase, int padding)
        {
            if (!int.TryParse(input, out int intput))
                return Program.Error($"Number: {input} isn't an int", input);

            return Convert.ToString(intput, NumBase).PadLeft(padding, '0');
        }
    }

    public static class MorseCodeSing
    {
        public static string SingMorseCode(string input, bool Multithreaded)
        {
            if (Multithreaded)
            {
                Thread morsecodethread = new(Sing);
                morsecodethread.Start(input);
                return input;
            }

            Sing(input);
            return input;
        }

        public static void Sing(object Input)
        {
            string morseCode = (string)Input;
            ProgressBar bar = new("Morse code (sing)", morseCode.Length);
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

    public static class CapsRandomizer
    {
        public static string Randomize(string Input)
        {
            ProgressBar bar = new("Randomize", Input.Length);
            string returnVal = "";
            Random rng = new();

            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();
                bool UpperOrLower = rng.Next(0, 2) == 1;

                returnVal += UpperOrLower ? Input[i].ToUpper() : Input[i].ToLower();
            }

            return returnVal;
        }
    }

    public static class Owoify
    {
        static readonly char[] vowels = new char[]
        {
            'a',
            'e',
            'i',
            'o',
            'u',
        };

        public static string Encode(string input)
        {
            ProgressBar bar = new("Owoify", input.Length);
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

            string[] splitByWords = returnValue.Split(' ');

            for (int i = 0; i < splitByWords.Length; i++)
            {
                if (splitByWords[i].StartsWith("l"))
                    splitByWords[i] = "w" + splitByWords[i][1..];
            }

            returnValue = splitByWords.ToRealString(' ').ToLower().Replace("ove", "uv").Replace("r", "w");

            return returnValue;
        }
    }

    public static class NumericAlphabet
    {
        public static string Encode(string input)
        {
            ProgressBar bar = new ("Numeric Alphabet (Encode)", input.Length);
            string returnValue = "";

            for (int i = 0; i < input.Length; i++)
            {
                bar.Increase();

                int index = AlphabetAndWords.alphabet.IndexOf(input[i].ToLower());

                if (input[i] == ' ')
                {
                    returnValue += " 0";
                    continue;
                }

                if (index == -1)
                {
                    Program.Error($"{input[i]} is not in the alphabet");
                    returnValue += $" {input[i]}";
                    continue;
                }

                returnValue += " " + (index + 1);
            }

            if (returnValue.Length == 0)
                return returnValue;

            return returnValue[1..];
        }

        public static string Decode(string input)
        {
            ProgressBar bar = new("Numeric Alphabet (Decode)", input.Length);
            string[] splitInput = input.Split(' ');
            string returnValue = "";

            for (int i = 0; i < splitInput.Length; i++)
            {
                bar.Increase();

                if (!uint.TryParse(splitInput[i], out uint currentChar))
                {
                    Program.Error($"{splitInput[i]} is not a positive number");
                    returnValue += splitInput[i];
                    continue;
                }

                if (currentChar == 0)
                {
                    returnValue += " ";
                    continue;
                }

                currentChar--;

                if (AlphabetAndWords.alphabet.Length <= currentChar)
                {
                    Program.Error($"{currentChar} is not in the alphabet (1-26)");
                    returnValue += currentChar;
                    continue;
                }

                returnValue += AlphabetAndWords.alphabet[(int)currentChar];
            }

            return returnValue;
        }
    }

    public static class Braille
    {
        public static string Decode(string Input)
        {
            ProgressBar bar = new("Braille (Decode)", Input.Length);
            Dictionary<string, string> targetdict = TextToEncode.braille.FlipDict();
            string returnValue = "";

            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();

                if (i + 1 < Input.Length)
                {
                    string currentPlus1 = $"{Input[i]}{Input[i + 1]}";
                    if (targetdict.ContainsKey(currentPlus1))
                    {
                        returnValue += currentPlus1;
                        i++;
                        continue;
                    }
                }

                if (targetdict.ContainsKey(Input[i].ToString()))
                    returnValue += targetdict[Input[i].ToString()];
                else
                    returnValue += Program.Error($"{Input[i]} is not a braille character!", Input[i].ToString());
            }

            return returnValue;
        }
    }

    public static class ToDiscordTimestamp
    {
        public static string Encode(string input, string formatType)
        {
            DateTime date;

            if (input.ToLower() == "now")
            {
                date = DateTime.Now;
            }
            else
            {
                if (!DateTime.TryParse(input, out date))
                    return Program.Error($"{input} is not a valid date!!", input);
            }

            long unixTime = ((DateTimeOffset)date).ToUnixTimeSeconds();

            return $"<t:{unixTime}:{GetFormatType(formatType)}>";
        }

        public static string GetFormatType(string input)
        {
            string cleanInput = Regex.Replace(input.ToLower(), @"[^a-z]+", "");

#pragma warning disable IDE0066 // Convert switch statement to expression
            switch (cleanInput)
#pragma warning restore IDE0066 // Convert switch statement to expression
            {
                default:
                    return input;
                case "mdy":
                case "monthdateyear":
                case "ddmmyy":
                    return "d";
                case "mdyt":
                case "monthdayyearttime":
                    return "f";
                case "t":
                case "time":
                    return "t";
                case "monthdayyear":
                case "mwdy":
                    return "T";
                case "mddy":
                case "monthdaydayyear":
                    return "D";
                case "weekdaymonthdayyeartime":
                case "wdmdyt":
                    return "F";
                case "timesince":
                case "ts":
                    return "R";
                case "hms":
                case "hoursminutesseconds":
                    return "T";
            }
        }
    }

    public static class Sprinkle
    {
        public static string Encode(string input, string item, uint frequency)
        {
            ProgressBar bar = new("Sprinkle", input.Length / (int)frequency);

            for (uint i = 0; i < input.Length; i += frequency)
            {
                bar.Increase();
                input = input.Insert((int)i, item);
                i += (uint)item.Length;
            }

            return input;
        }
    }

    public static class IncreaseVar
    { 
        public static void IncreaseMyVar(string[] Params, string input)
        {
            string varName = Params.SafeGet(1).ToLower();

            if (!MethodCode.variables.ContainsKey(varName))
            {
                Program.Error($"Increase: {varName} is not a variable");
                return;
            }

            if (!double.TryParse(MethodCode.variables[varName], out double variableToIncrease))
            {
                Program.Error($"Increase: var {MethodCode.variables[varName]} is not a number");
                return;
            }

            if (Params.Length <= 2)
            {
                MethodCode.variables[varName] = (variableToIncrease + 1).ToString();
                Program.Debug($"{varName} = {MethodCode.variables[varName]}");

                return;
            }

            if (!double.TryParse(Params.SafeGet(2), out double increaseResult))
            {
                Program.Error($"Increase: {Params.SafeGet(2)} is not a number");
                return;
            }

            MethodCode.variables[varName] = (variableToIncrease + increaseResult).ToString();
            Program.Debug($"{varName} = {MethodCode.variables[varName]}");
        }
    }
}
