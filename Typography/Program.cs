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
        public static RunMode runMode;
        public static int ProgressChunks = 10;

        public enum RunMode
        {
            exeFile,
            cmdMode,
            typFile,
        }

        [STAThread]
        public static void Main(string[] args)
        {
            runMode = args.Length > 0 ? RunMode.cmdMode : RunMode.exeFile;

            if (runMode == RunMode.exeFile)
            {
                Console.WriteLine("Please select some processes:\n");

                Console.WriteLine(AllTypes("\n"));

                Console.WriteLine("\nEnter your process string here (Ex: example;reverse;append~test):\n");
            }

            string Input = args.Length > 0 ? ArgsIntoString(args) : Console.ReadLine();

            if (args.Length == 1)
            {
                if (File.Exists(args[0]))
                {
                    runMode = RunMode.typFile;
                    Input = File.ReadAllText(args[0]);
                    Input = Input.Replace("\n", "").Replace("\r", "");
                }
            }

            string initialValue = Input.Split(';')[0];

            if (Input.Contains(";"))
                Input = Input.Substring(initialValue.Length + 1);
            else
                Input = "";

            initialValue = methodCode.CheckForVars(initialValue);
            MakeMethods(Input);
            Console.WriteLine(methodCode.methods["main"].compute(initialValue));
        }

        public static void MakeMethods(string Input)
        {
            List<string> stringSplitColon = Input.Split(":").ToList();

            if (!stringSplitColon[0].StartsWith(':'))
                stringSplitColon.Insert(0, "main");

            methodCode.methods.Add("null", new methodCode("null", ""));

            for (int i = 0; i < stringSplitColon.Count; i += 2)
            {
                if (i >= stringSplitColon.Count)
                    break;

                string methodName = stringSplitColon[i];
                string code = stringSplitColon[i + 1];

                if (methodCode.methods.ContainsKey(methodName))
                {
                    Error($"Method {methodName} has already been made");
                    continue;
                }

                methodCode.methods.Add(methodName, new methodCode(methodName, code));
            }
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

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }

        public static string Error(string message, string inputReturn)
        {
            Error(message);
            return inputReturn;
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
        uppercase,
        lowercase,
        smallcaps,
        bold,
        italics,
        bolditalics,
        clear,
        htmlText,
        call,
        delay,
        If,
        IfElse,
        leetspeak,
    }
}
