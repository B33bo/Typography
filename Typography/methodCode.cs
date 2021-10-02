using System;
using System.Collections.Generic;

namespace Typography
{
    public class MethodCode
    {
        public static Dictionary<string, MethodCode> methods = new();

        public static Dictionary<string, string> variables = new()
        {
            { @"\n", "\n" },
            { @"\r", "\r"},
            { "tstvar", "testing123" },
            { "percent", "%" },
            { "semicolon", ";" },
            { "colon", ":" },
            { "tilda", "~" },
            { "runmode", "Unknown"},
            { "time", "Unknown" },
            { "true", "True" },
            { "false", "False" },
            { "empty", string.Empty },
            { "pi", Math.PI.ToString() },
            { "e", Math.E.ToString() },
            { "tau", Math.Tau.ToString() },
            { "nan", double.NaN.ToString() },
            { "inf", double.PositiveInfinity.ToString() },
            { "-inf", double.NegativeInfinity.ToString() },
            { "clipboard", "" },
            { "randomchar", "" },
            { "randomalphabet", "" },
            { "uptime", "" },
            { "input", "" },
            { "whitespace", "	" },
            { "zerowidth", "​" },
            { "combining", "̾​" },
            { "sus", "ඞ​" },
            { "right-to-left", "‮" },

            { "disc_bold", "**"},
            { "disc_italics", "_"},
            { "disc_underline", "__"},
            { "disc_strikethrough", "~~" },
            { "disc_spoiler", "~~" },
            { "disc_robotic", "` " },
            { "disc_codeblock", "``` " },
            { "disc_excape", @"\" },
            { "disc_quote", "> " },
            { "disc_quotefull", ">>> " },
            { "disc_empty", "https://canary.discord.com/__development/link" },

            { "black", "Black" },
            { "darkblue", "DarkBlue" },
            { "darkgreen", "DarkGreen" },
            { "darkcyan", "DarkCyan" },
            { "darkred", "DarkRed" },
            { "darkmagenta", "DarkRed" },
            { "darkyellow", "DarkYellow" },
            { "gray", "Gray" },
            { "grey", "Gray" },
            { "darkgray", "DarkGray" },
            { "darkgrey", "DarkGray" },
            { "blue", "Blue" },
            { "green", "Green" },
            { "cyan", "Cyan" },
            { "red", "Red" },
            { "magenta", "Magenta" },
            { "yellow", "Yellow" },
            { "white", "White" },
        };

        public string[] commands;
        public string methodName;

        public MethodCode(string name, string code)
        {
            methodName = name;
            commands = code.Split(';');
        }

        public string Compute(string inputVar)
        {
            string returnValue = inputVar;
            for (int i = 0; i < commands.Length; i++)
            {
                string LookedForVars = CheckForVars(commands[i]);
                inputVar = CheckForVars(inputVar);

                string[] Params = LookedForVars.Split('~');
                string command = Params[0];

                if (Program.DebugMode)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"debug:: {Params.ToRealString('~')} ({returnValue})");
                    Console.ResetColor();
                    Console.ReadLine();
                }

                returnValue = Typography.DoTypographyType(command.ParseAsType(), returnValue, Params);
            }

            Program.Debug($"End of method {methodName}");
            return returnValue;
        }

        public static void ReassignChangingVariables()
        {
            variables["runmode"] = Program.runMode.ToString();
            variables["time"] = DateTime.Now.ToString();
            variables["clipboard"] = System.Windows.Forms.Clipboard.GetText();
            variables["uptime"] = Program.uptime.ElapsedMilliseconds.ToString();
            variables["input"] = Program.oldInput;
            variables["debug"] = Program.DebugMode.ToString();
        }

        public static string CheckForVars(string input, bool progressBar = false)
        {
            ProgressBar bar = null;

            if (progressBar)
                bar = new("Check for vars", input.Length);

            Random rnd = new();
            ReassignChangingVariables();
            string currentPercent = "";
            string returnValue = "";
            bool isInPercent = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (progressBar)
                    bar.Increase();

                variables["randomchar"] = ((char)rnd.Next(char.MinValue, char.MaxValue)).ToString();
                variables["randomalphabet"] = ((char)rnd.Next('a', 'z')).ToString();

                bool isFinalCharacter = i + 1 == input.Length;

                //escape sequences
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

                    if (variables.ContainsKey(currentPercent.ToLower()))
                    {
                        Program.Debug($"Found var {currentPercent.ToLower()} as {variables[currentPercent.ToLower()]}");
                        returnValue += variables[currentPercent.ToLower()];
                    }

                    else if (!isInPercent)
                        returnValue += $"%{currentPercent}%";

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

        public static string[] CheckForVars(string[] input)
        {
            string[] returnVal = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                returnVal[i] = CheckForVars(input[i]);
            }

            return returnVal;
        }
    }
}
