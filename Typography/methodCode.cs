﻿using System;
using System.Collections.Generic;

namespace Typography
{
    public class methodCode
    {
        public static Dictionary<string, methodCode> methods = new Dictionary<string, methodCode>();

        public static Dictionary<string, string> variables = new Dictionary<string, string>()
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
            { "uptime", "" },
            { "input", "" },

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

        public methodCode(string name, string code)
        {
            methodName = name;
            commands = code.Split(';');
        }

        public string compute(string inputVar)
        {
            string returnValue = inputVar;
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = CheckForVars(commands[i]);
                inputVar = CheckForVars(inputVar);

                string[] Params = commands[i].Split('~');
                string command = Params[0];

                returnValue = Typography.DoTypographyType(command.ParseAsType(), returnValue, Params);
            }

            return returnValue;
        }

        public static void ReassignChangingVariables()
        {
            variables["runmode"] = Program.runMode.ToString();
            variables["time"] = DateTime.Now.ToString();
            variables["clipboard"] = System.Windows.Forms.Clipboard.GetText();
            variables["uptime"] = Program.uptime.ElapsedMilliseconds.ToString();
            variables["input"] = Program.oldInput;
        }

        public static string CheckForVars(string input)
        {
            ReassignChangingVariables();
            string currentPercent = "";
            string returnValue = "";
            bool isInPercent = false;

            for (int i = 0; i < input.Length; i++)
            {
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
                        returnValue += variables[currentPercent.ToLower()];

                    else if (!isInPercent)
                    {
                        Program.Error($"{currentPercent} is not a variable");
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
    }
}
