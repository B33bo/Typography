using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class Braille
    {
        public static Dictionary<string, string> braille = new()
        {
            { "a", "⠁" },
            { "b", "⠃" },
            { "c", "⠉" },
            { "d", "⠙" },
            { "e", "⠑" },
            { "f", "⠋" },
            { "g", "⠛" },
            { "h", "⠓" },
            { "i", "⠊" },
            { "j", "⠚" },
            { "k", "⠅" },
            { "l", "⠇" },
            { "m", "⠍" },
            { "n", "⠝" },
            { "o", "⠕" },
            { "p", "⠏" },
            { "q", "⠟" },
            { "r", "⠗" },
            { "s", "⠎" },
            { "t", "⠞" },
            { "u", "⠥" },
            { "v", "⠧" },
            { "w", "⠺" },
            { "x", "⠭" },
            { "y", "⠽" },
            { "z", "⠵" },

            { "1", "⠁" },
            { "2", "⠃" },
            { "3", "⠉" },
            { "4", "⠙" },
            { "5", "⠑" },
            { "6", "⠋" },
            { "7", "⠛" },
            { "8", "⠓" },
            { "9", "⠊" },
            { "0", "⠚" },

            { "(", "⠐⠣" },
            { " ", "⠀" },
            { ")", "⠐⠜" },
            { ",", "⠂" },
            { ";", "⠆" },
            { ":", "⠒" },
            { "?", "⠦" },
            { "!", "⠖" },
            { "/", "⠸⠌" },
            { @"\", "⠸⠡" },
            { "-", "⠤" },
            { "–", "⠠⠤" },
            { "—", "⠐⠠⠤" },

            { "capital", "⠠" },
            { "number", "⠼" },
            { "endnumber", "⢠" },
        };

        public static string Encode(string input)
        {
            ProgressBar bar = new("Braille (encode)", input.Length);
            string digits = "0123456789";
            string newStr = "";

            bool isDigits = false;
            for (int i = 0; i < input.Length; i++)
            {
                string Character = input[i].ToString();

                if (digits.Contains(input[i]))
                {
                    if (!isDigits)
                        newStr += braille["number"];

                    newStr += braille[Character];

                    isDigits = true;
                    bar.Increase();
                    continue;
                }
                else if (isDigits)
                {
                    isDigits = false;
                    newStr += braille["endnumber"];
                }

                if (Character.ToLower() != Character)
                    //It's uppercase
                    newStr += braille["capital"];

                if (braille.ContainsKey(Character.ToLower()))
                    newStr += braille[Character.ToLower()];
                bar.Increase();
            }
            return newStr;
        }

        public static string Decode(string input)
        {
            Dictionary<string, string> charFromNumber = new()
            {
                { "⠁", "1" },
                { "⠃", "2" },
                { "⠉", "3" },
                { "⠙", "4" },
                { "⠑", "5" },
                { "⠋", "6" },
                { "⠛", "7" },
                { "⠓", "8" },
                { "⠊", "9" },
                { "⠚", "0" },
            };
            ProgressBar bar = new("Braille (decode)", input.Length);
            Dictionary<string, string> fromBraille = braille.FlipDict();
            string newStr = "";

            bool isDigits = false;
            bool isCaps = false;
            for (int i = 0; i < input.Length; i++)
            {
                bar.Increase();
                if (input[i] == '⠼')
                {
                    isDigits = true;
                    continue;
                }
                else if (input[i] == '⢠')
                {
                    isDigits = false;
                    continue;
                }
                else if (input[i] == '⠠')
                {
                    isCaps = true;
                    continue;
                }

                if (isDigits)
                    newStr += charFromNumber[input[i].ToString()];
                else
                {
                    if (!fromBraille.ContainsKey(input[i].ToString()))
                        continue;

                    if (isCaps)
                        newStr += fromBraille[input[i].ToString()].ToUpper();
                    else
                        newStr += fromBraille[input[i].ToString()];
                }
                isCaps = false;
            }
            return newStr;
        }
    }
}
