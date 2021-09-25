using System;
using System.Diagnostics;
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
        public static Stopwatch uptime = new();
        public static string oldInput = "";
        public static bool DebugMode = false;

        public enum RunMode
        {
            exeFile,
            cmdMode,
            typFile,
        }

        [STAThread]
        public static void Main(string[] args)
        {
            uptime.Start();
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
                Input = Input[(initialValue.Length + 1)..];
            else
                Input = "";

            initialValue = MethodCode.CheckForVars(initialValue);
            MakeMethods(Input);
            Console.WriteLine($"\n---\n{MethodCode.methods["main"].Compute(initialValue)}");
        }

        public static void MakeMethods(string Input)
        {
            List<string> stringSplitColon = Input.Split(":").ToList();

            if (!stringSplitColon[0].StartsWith(':'))
                stringSplitColon.Insert(0, "main");

            MethodCode.methods.Add("null", new MethodCode("null", ""));

            for (int i = 0; i < stringSplitColon.Count; i += 2)
            {
                if (i >= stringSplitColon.Count)
                    break;

                string methodName = stringSplitColon[i];
                string code = stringSplitColon[i + 1];

                if (MethodCode.methods.ContainsKey(methodName))
                {
                    Error($"Method {methodName} has already been made");
                    continue;
                }

                MethodCode.methods.Add(methodName, new MethodCode(methodName, code));
            }
        }

        public static string ArgsIntoString(string[] args)
        {
            string returnVal = "";

            foreach (string item in args)
            {
                returnVal += $" {item}";
            }

            return returnVal[1..];
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }

        public static T Error<T>(string message, T inputReturn)
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

            return returnValue[Seperator.Length..];
        }
    }
}
