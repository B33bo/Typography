using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Typography;

namespace Typography
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Please select some processes:\n");

            Console.WriteLine(AllTypes("\n"));

            Console.WriteLine("\nEnter your process string here:\n");

            Console.WriteLine(ProcessString(Console.ReadLine()));
        }

        public static string ProcessString(string input)
        {
            string[] commands = input.Split(';');
            string currentValue = commands[0];

            for (int i = 1; i < commands.Length; i++)
            {
                string[] Params = commands[i].Split('~');
                string command = Params[0];

                currentValue = DoTypographyType(command.ParseAsType(), currentValue, Params);
            }

            return currentValue;
        }

        [STAThread]
        public static string DoTypographyType(TypographyType type, string input, string[] Params)
        {
            bool toEncode = true;
            if (Params.Length > 1)
                toEncode = Params[1] == "true";

            switch (type)
            {
                case TypographyType.Normal:
                    return input;
                case TypographyType.Reverse:
                    return BackwardsText.Flip(input);
                case TypographyType.Upsideown:
                    return Upsidedown.Upsideown(input);
                case TypographyType.Randomize:
                    return Randomize.Jumble(input);
                case TypographyType.error:
                    Error(Params.Length > 1 ? Params[1] : "not yet implemented");
                    return input;
                case TypographyType.append:
                    return toEncode ? Append.ToEncoded(input, Params[2]) : Append.FromEncoded(input, Params[2]);
                case TypographyType.periodicTable:
                    return toEncode ? PeriodicTable.ToEncrypted(input) : PeriodicTable.FromEncrypted(input);
                case TypographyType.bigLetters:
                    break;
                case TypographyType.copyText:
                    Clipboard.SetText(input);
                    return input;
                case TypographyType.invertCondition:
                    break;
                case TypographyType.SentencePyramid:
                    break;
                case TypographyType.sevenSegmentDisplay:
                    break;
                case TypographyType.replaceXwithY:
                    break;
                case TypographyType.longerWord:
                    break;
                case TypographyType.shorterWord:
                    break;
                default:
                    break;
            }

            Error($"{type} is not yet implemented");
            return input;
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static string AllTypes(string Seperator)
        {
            string returnValue = "";
            foreach (TypographyType item in Enum.GetValues(typeof(TypographyType)))
            {
                returnValue += Seperator + item.ToReadableString();
            }

            if (returnValue.Length == 0)
                return returnValue;

            return returnValue.Substring(Seperator.Length);
        }
    }

    public enum TypographyType
    {
        Normal,
        Reverse,
        Upsideown,
        Randomize,
        error,
        append,
        periodicTable,
        bigLetters,
        copyText,
        invertCondition,
        SentencePyramid,
        sevenSegmentDisplay,
        replaceXwithY,
        longerWord,
        shorterWord,
    }

    public static class TypographyTypesExtension
    {
        public static string ToReadableString(this TypographyType input)
        {
            switch (input)
            {
                case TypographyType.Normal:
                    return "Normal              normal";
                case TypographyType.Reverse:
                    return "Reverse             reverse";
                case TypographyType.Upsideown:
                    return "Upsideown           upsidedown";
                case TypographyType.Randomize:
                    return "Randomize           randomize";
                case TypographyType.error:
                    return "error               error";
                case TypographyType.append:
                    return "append string       append";
                case TypographyType.periodicTable:
                    return "Periodic Table      periodic";
                case TypographyType.bigLetters:
                    return "Big Letters         big";
                case TypographyType.copyText:
                    return "Copy to Clipboard   copy";
                case TypographyType.invertCondition:
                    return "Invert as condition invertbool";
                case TypographyType.SentencePyramid:
                    return "Sentence Pyramid    pyramid";
                case TypographyType.sevenSegmentDisplay:
                    return "7-segment display   7segdisplay";
                case TypographyType.replaceXwithY:
                    return "replace X with Y    replace";
                case TypographyType.longerWord:
                    return "X longer than Y     longer";
                case TypographyType.shorterWord:
                    return "X shorter than Y    shorter";
                default:
                    return input.ToString();
            }
        }

        public static TypographyType ParseAsType(this string input)
        {
            switch (input.ToLower().Trim())
            {
                default:
                    return TypographyType.error;
                case "normal":
                    return TypographyType.Normal;
                case "reverse":
                    return TypographyType.Reverse;
                case "upsidedown":
                    return TypographyType.Upsideown;
                case "randomize":
                    return TypographyType.Randomize;
                case "error":
                    return TypographyType.error;
                case "append":
                    return TypographyType.append;
                case "periodic":
                    return TypographyType.periodicTable;
                case "big":
                    return TypographyType.bigLetters;
                case "copy":
                    return TypographyType.copyText;
                case "invertbool":
                    return TypographyType.invertCondition;
                case "pyramid":
                    return TypographyType.SentencePyramid;
                case "7segdisplay":
                    return TypographyType.sevenSegmentDisplay;
                case "replace":
                    return TypographyType.replaceXwithY;
                case "longer":
                    return TypographyType.longerWord;
                case "shorter":
                    return TypographyType.shorterWord;
            }
        }

        public static string toString(this char[] input)
        {
            string returnValue = "";
            foreach (var item in input)
            {
                returnValue += item;
            }

            return returnValue;
        }

        public static Dictionary<TValue, TKey> FlipDict<TKey, TValue>(this Dictionary<TKey, TValue> input)
        {
            List<TKey> keys = input.Keys.OfType<TKey>().ToList();
            List<TValue> values = input.Values.OfType<TValue>().ToList();

            Dictionary<TValue, TKey> returnValue = new Dictionary<TValue, TKey>();

            for (int i = 0; i < keys.Count; i++)
            {
                returnValue.Add(values[i], keys[i]);
            }

            return returnValue;
        }
    }
}