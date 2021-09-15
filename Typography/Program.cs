using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Typography;

namespace Typography
{
    class Program
    {
        public static bool hasArgs;
        public static int ProgressChunks = 10;
        public static Dictionary<string, string> variables = new Dictionary<string, string>()
        {
            { @"\n", "\n" },
            { @"\r", "\r"},
            { "tstvar", "testing123" },
            { "percent", "%" },
            { "semicolon", ";" },
            { "tilda", "~" },
        };

        [STAThread]
        public static void Main(string[] args)
        {
            hasArgs = args.Length > 0;

            if (!hasArgs)
            {
                Console.WriteLine("Please select some processes:\n");

                Console.WriteLine(AllTypes("\n"));

                Console.WriteLine("\nEnter your process string here (Ex: example;reverse;append~test):\n");
            }

            string Input = args.Length > 0 ? ArgsIntoString(args) : Console.ReadLine();
            Input.Replace("\n", "");

            if (args.Length == 1)
            {
                if (!args[0].Contains(";") && File.Exists(args[0]))
                {
                    Input = File.ReadAllText(args[0]);
                }
            }

            Console.WriteLine($"\n---\n{ProcessString(Input)}");
        }

        public static string ArgsIntoString(string[] args)
        {
            string returnVal = "";

            foreach (string item in args)
            {
                returnVal += $" {item}";
            }

            return returnVal.Substring(1);
        }

        public static string ProcessString(string input)
        {
            input = CheckForVars(input);

            string[] commands = input.Split(';');
            string currentValue = commands[0];

            for (int i = 1; i < commands.Length; i++)
            {
                string[] Params = commands[i].Split('~');
                string command = Params[0];

                currentValue = DoTypographyType(command.ParseAsType(), currentValue, Params);
                currentValue = CheckForVars(currentValue);
            }

            return currentValue;
        }

        static string CheckForVars(string input)
        {
            string currentPercent = "";
            string returnValue = "";
            bool isInPercent = false;

            for (int i = 0; i < input.Length; i++)
            {
                bool isFinalCharacter = i + 1 == input.Length;

                if (input[i] == '\\' && !isFinalCharacter)
                {
                    string resultingChar = input[i].ToString() + input[i + 1].ToString();

                    if (isInPercent)
                        currentPercent += resultingChar;
                    else
                        returnValue += resultingChar;
                    i++;
                    continue;
                }

                if (input[i] == '%')
                {
                    isInPercent = !isInPercent;

                    if (variables.ContainsKey(currentPercent))
                        returnValue += variables[currentPercent];
                    else if (!isInPercent)
                    {
                        returnValue += $"%{currentPercent}%";
                    }

                    currentPercent = "";
                    continue;
                }

                if (isInPercent)
                    currentPercent += input[i];
                else
                    returnValue += input[i];
            }

            if (isInPercent)
                returnValue += "%" + currentPercent;

            return returnValue;
        }

        public static bool StringIsTrue(string[] Params, int index, bool defaultValue)
        {
            if (Params.Length <= index)
                return defaultValue;

            if (Params[index].Length == 0)
                return defaultValue;

            if (Params[index].ToLower()[0] == 'e')
                return true;

            if (Params[index].ToLower() == "true")
                return true;

            if (Params[index].ToLower()[0] == 'y')
                return true;

            return false;
        }

        [STAThread]
        public static string DoTypographyType(TypographyType type, string input, string[] Params)
        {
            bool toEncode = true;

            if (Params.Length > 1)
                toEncode = StringIsTrue(Params, 1, true);

            switch (type)
            {
                case TypographyType.None:
                    return input;

                case TypographyType.Normal:
                    return input;

                case TypographyType.Reverse:
                    return BackwardsText.Flip(input);

                case TypographyType.Upsideown:
                    return Upsidedown.Upsideown(input);

                case TypographyType.Randomize:
                    return Randomize.Jumble(input);

                case TypographyType.error:
                    bool fromUser = Params[0].ToLower() == "error";
                    string hardCodedError = $"{Params[0]} is an invalid command";

                    if (fromUser)
                        Error(Params.Length >= 2 ? Params[1] : input);
                    else
                        Error(hardCodedError);

                    return input;

                case TypographyType.append:
                    new ProgressBar("Append", 1, 1).Print();

                    return StringIsTrue(Params, 2, true) ? input + Params.safeGet(1) :
                        Append.Decode(input, Params.safeGet(1));

                case TypographyType.periodicTable:
                    return toEncode ? PeriodicTable.Encode(input) : PeriodicTable.Decode(input);

                case TypographyType.bigLetters:
                    return toEncode ? BigLetters.Encode(input) : ConvertToHashtable.Encode(input);

                case TypographyType.copyText:
                    new ProgressBar("Copy", 1, 1).Print();

                    if (input == string.Empty)
                        Error("Cannot copy empty string!!");
                    else
                        Clipboard.SetText(input);

                    return input;

                case TypographyType.invertCondition:
                    return InvertCondition.FlipCondition(input);

                case TypographyType.SentencePyramid:
                    return SentencePyramid.sentencePyramid(input);

                case TypographyType.sevenSegmentDisplay:
                    return sevenSegDisplay.SevenSegDisplay(input).ToString();

                case TypographyType.replaceXwithY:
                    return replaceXwithY.ReplaceXwithY(input, Params.safeGet(1), Params.safeGet(2));

                case TypographyType.longerWord:
                    new ProgressBar("longer", 1, 1).Print();
                    return longerAndShorter.Longer(input, Params.safeGet(1));

                case TypographyType.shorterWord:
                    new ProgressBar("shorter", 1, 1).Print();
                    return longerAndShorter.Shorter(input, Params.safeGet(1));

                case TypographyType.equal:
                    new ProgressBar("equal", 1, 1).Print();
                    return longerAndShorter.EqualTo(input, Params.safeGet(1)).ToString();

                case TypographyType.discordemoji:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.discordEmoji, "Discord Emoji (decode)", " ") :
                        TextToEncode.Decode(input, TextToEncode.discordEmoji, "Discord Emoji (decode)", " ");

                case TypographyType.bubble:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.BubbleText, "Bubble text (encode)") :
                        TextToEncode.Decode(input, TextToEncode.BubbleText, "Bubble text (decode)");

                case TypographyType.blackbubble:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.blackBubbleText, "Black bubble (encode)") :
                        TextToEncode.Decode(input, TextToEncode.blackBubbleText, "Black bubble (decode)");

                case TypographyType.userinput:
                    return Console.ReadLine();

                case TypographyType.repeat:
                    if (!int.TryParse(Params.safeGet(1), out int res))
                        Error($"'{Params.safeGet(1)}' is not a string.");

                    return TextToEncode.Repeat(input, res, StringIsTrue(Params, 2, true));

                case TypographyType.oldSchool:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.oldSchool, "Old school (encode)") :
                        TextToEncode.Decode(input, TextToEncode.oldSchool, "Old school (decode)");

                case TypographyType.write:
                    new ProgressBar("Write to file", 1, 1).Print();

                    try
                    {
                        if (!File.Exists(Params.safeGet(1)))
                        {
                            Error($"{Params.safeGet(1)} is not a file. Cannot write to");
                            return input;
                        }
                        File.WriteAllText(Params.safeGet(1), input);
                    }
                    catch (IOException exc)
                    {
                        Error("An error occured when writing to disc: " + exc.Message);
                    }
                    return input;

                case TypographyType.read:
                    new ProgressBar("Read from file", 1, 1).Print();

                    try
                    {
                        if (!File.Exists(input))
                        {
                            Error($"{input} is not a file. Cannot read from");
                            return input;
                        }
                        return File.ReadAllText(input);
                    }
                    catch (IOException exc)
                    {
                        Error("An error occured when reading from disc: " + exc.Message);
                        return input;
                    }

                case TypographyType.zalgo:
                    if (Params.Length == 1)
                        return Zalgo.Encode(input);

                    if (Params.Length == 2)
                    {
                        return StringIsTrue(Params, 1, true) ? Zalgo.Encode(input) :
                            Zalgo.Decode(input);
                    }

                    uint zalgup = 0;
                    uint zalgmid = 0;
                    uint zalgdown = 0;

                    if (!uint.TryParse(Params.safeGet(1), out zalgup) ||
                        !uint.TryParse(Params.safeGet(2), out zalgmid) ||
                        !uint.TryParse(Params.safeGet(3), out zalgdown))
                    {
                        Error($"Either {Params.safeGet(1)}, {Params.safeGet(2)}, or {Params.safeGet(3)} was not a positive number");
                        return input;
                    }

                    return Zalgo.Encode(input, zalgup, zalgmid, zalgdown);

                case TypographyType.expand:
                    if (!uint.TryParse(Params.safeGet(1), out uint expandness))
                    {
                        Error($"{Params.safeGet(1)} is not a positive number");
                        return input;
                    }
                    return StringIsTrue(Params, 2, true) ? expand.Encode(input, expandness) :
                        expand.Decode(input, expandness);

                case TypographyType.doubleStruck:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.doubleStruck, "Double struck (encode)") :
                        TextToEncode.Decode(input, TextToEncode.doubleStruck, "Double struck (decode)");

                case TypographyType.discordSpoiler:
                    return toEncode ? discordSpoiler.Encode(input) : discordSpoiler.Decode(input);

                case TypographyType.morsecode:
                    if (Params.Length >= 2)
                        if (Params[1] == "sing")
                            return MorseCodeSing.SingMorseCode(input, StringIsTrue(Params, 2, true));

                    return toEncode ? TextToEncode.Encode(input, TextToEncode.morseCode, "Morse code (encode)", " / ") :
                        TextToEncode.Decode(input, TextToEncode.morseCode, "Morse code (decode)", "/");

                case TypographyType.nato:
                    return toEncode ? Phonetics.Encode(input, Phonetics.NATO, "NATO (encode)") :
                        Phonetics.Decode(input, "NATO (decode)");

                case TypographyType.binary:
                    return toEncode ? BinaryText.Encode(input) : BinaryText.Decode(input);

                case TypographyType.number:
                    int BaseForEncoding = 10;
                    int padding = 2;

                    if (Params.Length >= 2)
                    {
                        if (!int.TryParse(Params.safeGet(2), out BaseForEncoding) ||
                            !int.TryParse(Params.safeGet(3), out padding))
                        {
                            Error($"Either {Params.safeGet(2)} or {Params.safeGet(3)} was not an int");
                        }
                    }

                    return toEncode ? Number.Encode(input, BaseForEncoding, padding) :
                        Number.Decode(input, BaseForEncoding, padding);

                case TypographyType.hash:
                    return Hashing.Hash(input, Params.safeGet(1));

                case TypographyType.googleTranslate:
                    return GTranslator.Translate(input, Params.safeGet(1), Params.safeGet(2));

                case TypographyType.nonsensify:
                    return GTranslator.Nonsense(input);

                case TypographyType.caesar:
                    if (!int.TryParse(Params.safeGet(1), out int CaesarAmount))
                    {
                        Error($"{Params.safeGet(1)} was not an int");
                        return input;
                    }

                    return Caesar.Encode(input, CaesarAmount);

                case TypographyType.capsRandomizer:
                    return capsRandomizer.Randomize(input);

                case TypographyType.owoify:
                    return owoify.Encode(input);

                case TypographyType.set:
                    variables.Add(Params.safeGet(1), input);
                    return input;

                case TypographyType.change:
                    return Params.safeGet(1);

                case TypographyType.substring:
                    if (!int.TryParse(Params.safeGet(1), out int start))
                    {
                        Error($"Substring: {Params.safeGet(1)} was not an int");
                    }

                    int substringLength = -1;
                    if (Params.Length > 2)
                    {
                        if (!int.TryParse(Params.safeGet(2), out substringLength))
                        {
                            Error($"Substring: {Params.safeGet(2)} was not an int");
                        }
                    }

                    if (start + substringLength > input.Length)
                    {
                        Error($"Start bound + length ({start + substringLength}) is higher than the length of the string ({input.Length})");
                        return input;
                    }

                    if (substringLength < 0)
                        return input.Substring(start);

                    return input.Substring(start, substringLength);

                case TypographyType.appendBehind:
                    if (StringIsTrue(Params, 2, true))
                    {
                        return Params.safeGet(1) + input;
                    }
                    else
                    {
                        string param1 = Params.safeGet(1);
                        return input.Substring(param1.Length, input.Length - param1.Length);
                    }

                case TypographyType.length:
                    return input.Length.ToString();

                default:
                    break;
            }

            Error($"{type} is not yet implemented");
            return input;
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message);
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
        None,
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
        equal,
        discordemoji,
        bubble,
        blackbubble,
        userinput,
        repeat,
        oldSchool,
        write,
        read,
        zalgo,
        expand,
        doubleStruck,
        discordSpoiler,
        morsecode,
        nato,
        binary,
        number,
        hash,
        googleTranslate,
        nonsensify,
        caesar,
        capsRandomizer,
        owoify,
        set,
        change,
        substring,
        appendBehind,
        length,
    }

    public static class TypographyExtention
    {
        public static string ToReadableString(this TypographyType input)
        {
            switch (input)
            {
                case TypographyType.Normal:
                    return "Normal                  normal";
                case TypographyType.Reverse:
                    return "Reverse                 reverse";
                case TypographyType.Upsideown:
                    return "Upsideown               upsidedown";
                case TypographyType.Randomize:
                    return "Randomize               randomize";
                case TypographyType.error:
                    return "error                   error";
                case TypographyType.append:
                    return "append string           append~X~encode/decode";
                case TypographyType.periodicTable:
                    return "Periodic Table          periodic~encode/decode";
                case TypographyType.bigLetters:
                    return "Big Letters             big";
                case TypographyType.copyText:
                    return "Copy to Clipboard       copy";
                case TypographyType.invertCondition:
                    return "Invert as condition     invertbool";
                case TypographyType.SentencePyramid:
                    return "Sentence Pyramid        pyramid~encode/decode";
                case TypographyType.sevenSegmentDisplay:
                    return "7-segment display       7segdisplay";
                case TypographyType.replaceXwithY:
                    return "replace X with Y        replace~X~Y";
                case TypographyType.longerWord:
                    return "X longer than Y         longer~Y";
                case TypographyType.shorterWord:
                    return "X shorter than Y        shorter~Y";
                case TypographyType.equal:
                    return "X equal length to Y     equal";
                case TypographyType.discordemoji:
                    return "discord emoji speak     discordemoji~encode/decode";
                case TypographyType.bubble:
                    return "bubble text             bubble~encode/decode";
                case TypographyType.blackbubble:
                    return "black bubble text       blackbubble~encode/decode";
                case TypographyType.userinput:
                    return "user input              input";
                case TypographyType.repeat:
                    return "repeat                  repeat~X~encode/decode";
                case TypographyType.oldSchool:
                    return "Old School              oldschool~encode/decode";
                case TypographyType.write:
                    return "Write to file           write~path";
                case TypographyType.read:
                    return "Read from file          read";
                case TypographyType.zalgo:
                    return "Zalgo                   zalgo~encode/decode~zalgoUp~zalgoMid~zalgoDown";
                case TypographyType.expand:
                    return "eexxppaanndd (expand)   expand~amount~encode/decode";
                case TypographyType.doubleStruck:
                    return "double struck           doublestruck~encode/decode";
                case TypographyType.discordSpoiler:
                    return "discord spoiler         spoiler~encode/decode";
                case TypographyType.morsecode:
                    return "morse code              morsecode~encode/decode/sing";
                case TypographyType.nato:
                    return "nato (alfa, bravo...)   nato~encode/decode";
                case TypographyType.binary:
                    return "binary                  binary~encode/decode";
                case TypographyType.number:
                    return "number                  number~encode/decode~base~padding";
                case TypographyType.hash:
                    return "hash                    hash~sha1/sha256/sha384/sha512/md5";
                case TypographyType.googleTranslate:
                    return "google translate        translate~fromLanguage~toLanguage";
                case TypographyType.nonsensify:
                    return "nonsensify              nonsensify";
                case TypographyType.caesar:
                    return "caesar cipher           caesar~chars";
                case TypographyType.capsRandomizer:
                    return "cAps RaANdoMIzer        caps";
                case TypographyType.owoify:
                    return "owoify                  owoify";
                case TypographyType.set:
                    return "set variable            set~name";
                case TypographyType.change:
                    return "change current string   change~value";
                case TypographyType.appendBehind:
                    return "append behind           appendbehind~value~encode/decode";
                case TypographyType.length:
                    return "length of string        length";
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
                case "equal":
                    return TypographyType.equal;
                case "discordemoji":
                    return TypographyType.discordemoji;
                case "bubble":
                    return TypographyType.bubble;
                case "blackbubble":
                    return TypographyType.blackbubble;
                case "input":
                    return TypographyType.userinput;
                case "repeat":
                    return TypographyType.repeat;
                case "oldschool":
                    return TypographyType.oldSchool;
                case "write":
                    return TypographyType.write;
                case "read":
                    return TypographyType.read;
                case "zalgo":
                    return TypographyType.zalgo;
                case "expand":
                    return TypographyType.expand;
                case "doublestruck":
                    return TypographyType.doubleStruck;
                case "spoiler":
                    return TypographyType.discordSpoiler;
                case "morsecode":
                    return TypographyType.morsecode;
                case "nato":
                    return TypographyType.nato;
                case "binary":
                    return TypographyType.binary;
                case "number":
                    return TypographyType.number;
                case "hash":
                    return TypographyType.hash;
                case "translate":
                    return TypographyType.googleTranslate;
                case "nonsensify":
                    return TypographyType.nonsensify;
                case "caesar":
                    return TypographyType.caesar;
                case "caps":
                    return TypographyType.capsRandomizer;
                case "owoify":
                    return TypographyType.owoify;
                case "set":
                    return TypographyType.set;
                case "change":
                    return TypographyType.change;
                case "substring":
                    return TypographyType.substring;
                case "appendbehind":
                    return TypographyType.appendBehind;
                case "length":
                    return TypographyType.length;
                case "":
                case " ":
                    return TypographyType.None;
            }
        }

        public static T safeGet<T>(this T[] array, int index, T defaultValue)
        {
            if (array.Length == 0)
            {
                Program.Error("Not any params (0)");
                return defaultValue;
            }

            if (array.Length <= index)
            {
                Program.Error($"{array[0]} does not have enough params ({array.Length})");
                return array[0];
            }

            return array[index];
        }

        public static T safeGet<T>(this T[] array, int index)
        {
            if (array.Length == 0)
            {
                Program.Error("Not any params (0)");
                return default(T);
            }

            if (array.Length <= index)
            {
                Program.Error($"{array[0]} does not have enough params ({array.Length})");
                return default(T);
            }

            return array[index];
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
                if (returnValue.ContainsKey(values[i]))
                    continue;

                returnValue.Add(values[i], keys[i]);
            }

            return returnValue;
        }

        public static char ToLower(this char str)
        {
            return Char.ToLower(str);
        }

        public static char ToUpper(this char str)
        {
            return Char.ToUpper(str);
        }
    }
}