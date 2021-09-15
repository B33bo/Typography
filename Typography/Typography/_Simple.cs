using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Typography
{
    public static class TextToEncode
    {
        public static Dictionary<string, string> blackBubbleText = new Dictionary<string, string>()
        {
            {"a", "🅐"},
            {"b", "🅑"},
            {"c", "🅒"},
            {"d", "🅓"},
            {"e", "🅔"},
            {"f", "🅕"},
            {"g", "🅖"},
            {"h", "🅗"},
            {"i", "🅘"},
            {"j", "🅙"},
            {"k", "🅚"},
            {"l", "🅛"},
            {"m", "🅜"},
            {"n", "🅝"},
            {"o", "🅞"},
            {"p", "🅟"},
            {"q", "🅠"},
            {"r", "🅡"},
            {"s", "🅢"},
            {"t", "🅣"},
            {"u", "🅤"},
            {"v", "🅥"},
            {"w", "🅦"},
            {"x", "🅧"},
            {"y", "🅨"},
            {"z", "🅩"},
            {"1", "➊"},
            {"2", "➋"},
            {"3", "➌"},
            {"4", "➍"},
            {"5", "➎"},
            {"6", "➏"},
            {"7", "➐"},
            {"8", "➑"},
            {"9", "➒"},
            {"0", "⓿"},
        };

        public static Dictionary<string, string> BubbleText = new Dictionary<string, string>()
        {
            {"A", "Ⓐ"},
            {"a", "ⓐ"},
            {"B", "Ⓑ"},
            {"b", "ⓑ"},
            {"C", "Ⓒ"},
            {"c", "ⓒ"},
            {"D", "Ⓓ"},
            {"d", "ⓓ"},
            {"E", "Ⓔ"},
            {"e", "ⓔ"},
            {"F", "Ⓕ"},
            {"f", "ⓕ"},
            {"G", "Ⓖ"},
            {"g", "ⓖ"},
            {"H", "Ⓗ"},
            {"h", "ⓗ"},
            {"I", "Ⓘ"},
            {"i", "ⓘ"},
            {"J", "Ⓙ"},
            {"j", "ⓙ"},
            {"K", "Ⓚ"},
            {"k", "ⓚ"},
            {"L", "Ⓛ"},
            {"l", "ⓛ"},
            {"M", "\\Ⓜ"},
            {"m", "ⓜ"},
            {"N", "Ⓝ"},
            {"n", "ⓝ"},
            {"O", "Ⓞ"},
            {"o", "ⓞ"},
            {"P", "Ⓟ"},
            {"p", "ⓟ"},
            {"Q", "Ⓠ"},
            {"q", "ⓠ"},
            {"R", "Ⓡ"},
            {"r", "ⓡ"},
            {"S", "Ⓢ"},
            {"s", "ⓢ"},
            {"T", "Ⓣ"},
            {"t", "ⓣ"},
            {"U", "Ⓤ"},
            {"u", "ⓤ"},
            {"V", "Ⓥ"},
            {"v", "ⓥ"},
            {"W", "Ⓦ"},
            {"w", "ⓦ"},
            {"X", "Ⓧ"},
            {"x", "ⓧ"},
            {"Y", "Ⓨ"},
            {"y", "ⓨ"},
            {"Z", "Ⓩ"},
            {"z", "ⓩ"},
            {"1", "①"},
            {"2", "②"},
            {"3", "③"},
            {"4", "④"},
            {"5", "⑤"},
            {"6", "⑥"},
            {"7", "⑦"},
            {"8", "⑧"},
            {"9", "⑨"},
            {"0", "⓪"},
        };

        public static Dictionary<string, string> oldSchool = new Dictionary<string, string>()
        {
            {"A", "𝔄"},
            {"a", "𝔞"},
            {"B", "𝔅"},
            {"b", "𝔟"},
            {"C", "ℭ"},
            {"c", "𝔠"},
            {"D", "𝔇"},
            {"d", "𝔡"},
            {"E", "𝔈"},
            {"e", "𝔢"},
            {"F", "𝔉"},
            {"f", "𝔣"},
            {"G", "𝔊"},
            {"g", "𝔤"},
            {"H", "ℌ"},
            {"h", "𝔥"},
            {"I", "ℑ"},
            {"i", "𝔦"},
            {"J", "𝔍"},
            {"j", "𝔧"},
            {"K", "𝔎"},
            {"k", "𝔨"},
            {"L", "𝔏"},
            {"l", "𝔩"},
            {"M", "𝔐"},
            {"m", "𝔪"},
            {"N", "𝔑"},
            {"n", "𝔫"},
            {"O", "𝔒"},
            {"o", "𝔬"},
            {"P", "𝔓"},
            {"p", "𝔭"},
            {"Q", "𝔔"},
            {"q", "𝔮"},
            {"R", "ℜ"},
            {"r", "𝔯"},
            {"S", "𝔖"},
            {"s", "𝔰"},
            {"T", "𝔗"},
            {"t", "𝔱"},
            {"U", "𝔘"},
            {"u", "𝔲"},
            {"V", "𝔙"},
            {"v", "𝔳"},
            {"W", "𝔚"},
            {"w", "𝔴"},
            {"X", "𝔛"},
            {"x", "𝔵"},
            {"Y", "𝔜"},
            {"y", "𝔶"},
            {"Z", "ℨ"},
            {"z", "𝔷"},
            {"3", "ℨ"},
        };

        public static Dictionary<string, string> doubleStruck = new Dictionary<string, string>()
        {
            {"A","𝔸"},
            {"a","𝕒"},
            {"B","𝔹"},
            {"b","𝕓"},
            {"C","ℂ"},
            {"c","𝕔"},
            {"D","𝔻"},
            {"d","𝕕"},
            {"E","𝔼"},
            {"e","𝕖"},
            {"F","𝔽"},
            {"f","𝕗"},
            {"G","𝔾"},
            {"g","𝕘"},
            {"H","ℍ"},
            {"h","𝕙"},
            {"I","𝕀"},
            {"i","𝕚"},
            {"J","𝕁"},
            {"j","𝕛"},
            {"K","𝕂"},
            {"k","𝕜"},
            {"L","𝕃"},
            {"l","𝕝"},
            {"M","𝕄"},
            {"m","𝕞"},
            {"N","ℕ"},
            {"n","𝕟"},
            {"O","𝕆"},
            {"o","𝕠"},
            {"P","ℙ"},
            {"p","𝕡"},
            {"Q","ℚ"},
            {"q","𝕢"},
            {"R","ℝ"},
            {"r","𝕣"},
            {"S","𝕊"},
            {"s","𝕤"},
            {"T","𝕋"},
            {"t","𝕥"},
            {"U","𝕌"},
            {"u","𝕦"},
            {"V","𝕍"},
            {"v","𝕧"},
            {"W","𝕎"},
            {"w","𝕨"},
            {"X","𝕏"},
            {"x","𝕩"},
            {"Y","𝕐"},
            {"y","𝕪"},
            {"z","𝕫"},
            {"Z","ℤ"},
            {"1","𝟙"},
            {"2","𝟚"},
            {"3","𝟛"},
            {"4","𝟜"},
            {"5","𝟝"},
            {"6","𝟞"},
            {"7","𝟟"},
            {"8","𝟠"},
            {"9","𝟡"},
            {"0","𝟘"},
        };

        public static Dictionary<string, string> discordEmoji = new Dictionary<string, string>()
        {
            {"a", ":regional_indicator_a:"},
            {"b", ":regional_indicator_b:"},
            {"c", ":regional_indicator_c:"},
            {"d", ":regional_indicator_d:"},
            {"e", ":regional_indicator_e:"},
            {"f", ":regional_indicator_f:"},
            {"g", ":regional_indicator_g:"},
            {"h", ":regional_indicator_h:"},
            {"i", ":regional_indicator_i:"},
            {"j", ":regional_indicator_j:"},
            {"k", ":regional_indicator_k:"},
            {"l", ":regional_indicator_l:"},
            {"m", ":regional_indicator_m:"},
            {"n", ":regional_indicator_n:"},
            {"o", ":regional_indicator_o:"},
            {"p", ":regional_indicator_p:"},
            {"q", ":regional_indicator_q:"},
            {"r", ":regional_indicator_r:"},
            {"s", ":regional_indicator_s:"},
            {"t", ":regional_indicator_t:"},
            {"u", ":regional_indicator_u:"},
            {"v", ":regional_indicator_v:"},
            {"w", ":regional_indicator_w:"},
            {"x", ":regional_indicator_x:"},
            {"y", ":regional_indicator_y:"},
            {"z", ":regional_indicator_z:"},
            {" ", ":blue_square:"},
            {"1", ":one:"},
            {"2", ":two:"},
            {"3", ":three:"},
            {"4", ":four:"},
            {"5", ":five:"},
            {"6", ":six:"},
            {"7", ":seven:"},
            {"8", ":eight:"},
            {"9", ":nine:"},
            {"0", ":zero:"},
            {"#", ":hash:"},
            {"*", ":asterisk:"},
            {">", ":arrow_forward:"},
            {"<", ":arrow_backward:"},
            {"^", ":arrow_up_small:"},
            {"/", ":arrow_upper_right:"},
            {"\\", ":arrow_lower_right:"},
            {"|", ":pause_button:"},
            {".", ":record_button:"},
            {"+", ":heavy_plus_sign:"},
            {"-", ":heavy_minus_sign:"},
            {"÷", ":heavy_division_sign:"},
            {",", ":arrow_heading_up:"},
            {"!", ":exclamation:"},
            {"?", ":question:"},
            {"$", ":dollar:"},
            {"£", ":pound:"},
            {"€", ":euro:"},
            {"¥", ":yen:"},
            {"₿", ":coin:"},
            {"(", ":arrow_right_hook:"},
            {"{", ":arrow_right_hook:"},
            {")", ":leftwards_arrow_with_hook:"},
            {"}", ":leftwards_arrow_with_hook:"},
        };

        public static Dictionary<string, string> morseCode = new Dictionary<string, string>()
        {
            {"a", ".-"},
            {"b", "-..."},
            {"c", "-.-."},
            {"d", "-.."},
            {"e", "."},
            {"f", "..-."},
            {"g", "--."},
            {"h", "...."},
            {"i", ".."},
            {"j", ".---"},
            {"k", "-.-"},
            {"l", ".-.."},
            {"m", "--"},
            {"n", "-."},
            {"o", "---"},
            {"p", ".--."},
            {"q", "--.-"},
            {"r", ".-."},
            {"s", "..."},
            {"t", "-"},
            {"u", "..-"},
            {"v", "...-"},
            {"w", ".--"},
            {"x", "-..-"},
            {"y", "-.--"},
            {"z", "--.."},
            {"0", "-----"},
            {"1", ".----"},
            {"2", "..---"},
            {"3", "...--"},
            {"4", "....-"},
            {"5", "....."},
            {"6", "-...."},
            {"7", "--..."},
            {"8", "---.."},
            {"9", "----."},
            {"error", "......."},
            {"&", ".-..."},
            {"'", ".----."},
            {"@", ".--.-."},
            {")", "-.--.-"},
            {"(", "-.--."},
            {":", "---..."},
            {",", "--..--"},
            {"=", "-...-"},
            {"!", "-.-.--"},
            {".", ".-.-.-"},
            {"-", "-....-"},
            {"×", "-..-"},
            {"%", "----- -..-. -----"},
            {"+", ".-.-."},
            {"\"", ".-..-."},
            {"?", "..--.."},
            {"/", "-..-."},
            {"à", ".--.-"},
            {"å", ".--.-"},
            {"ä", ".-.-"},
            {"ą", ".-.-"},
            {"æ", ".-.-"},
            {"ĉ", "-.-.."},
            {"ć", "-.-.."},
            {"ç", "-.-.."},
            {"ch", "----"},
            {"ĥ", "----"},
            {"š", "----"},
            {"đ", "..-.."},
            {"é", "..-.."},
            {"ę", "..-.."},
            {"ð", "..--."},
            {"è", ".-..-"},
            {"ł", ".-..-"},
            {"ĝ", "--.-."},
            {"ĵ", ".---."},
            {"ń", "--.--"},
            {"ñ", "--.--"},
            {"ó", "---."},
            {"ö", "---."},
            {"ø", "---."},
            {"ś", "...-..."},
            {"ŝ", "...-."},
            {"þ", ".--.."},
            {"ü", "..--"},
            {"ŭ", "..--"},
            {"ź", "--..-."},
            {"ż", "--..-"},
        };

        public static string[] ToStringArray(this char[] c)
        {
            string[] returnValue = new string[c.Length];

            for (int i = 0; i < c.Length; i++)
            {
                returnValue[i] = c[i].ToString();
            }

            return returnValue;
        }

        public static string Encode(string Input, Dictionary<string, string> keys, string ProgressBarName, string seperator = "", string splitter = "")
        {
            string[] InputSplit = Input.Split(splitter);

            if (splitter == "")
                InputSplit = Input.ToArray().ToStringArray();

            string returnValue = "";
            ProgressBar bar = new ProgressBar(ProgressBarName, InputSplit.Length);

            for (int i = 0; i < InputSplit.Length; i++)
            {
                bar.Increase();
                string current = InputSplit[i];
                string withoutSpace = InputSplit[i].Replace(" ", "");

                if (keys.ContainsKey(current))
                    returnValue += seperator + keys[current];

                else if (keys.ContainsKey(current.ToLower()))
                    returnValue += seperator + keys[current.ToLower()];

                else if (InputSplit[i] == " " || InputSplit[i] == "\n" || InputSplit[i] == "\r" || InputSplit[i] == "")
                {
                    returnValue += InputSplit[i];
                    continue;
                }

                else if (keys.ContainsKey(withoutSpace))
                    returnValue += seperator + keys[withoutSpace];

                else if (keys.ContainsKey(withoutSpace.ToLower()))
                    returnValue += seperator + keys[withoutSpace.ToLower()];

                else
                {
                    if (keys.ContainsKey("error"))
                        returnValue += seperator + keys["error"];
                    else
                        returnValue += $"{seperator}{InputSplit[i]}";

                    Program.Error($"{ProgressBarName}: Cannot convert key {InputSplit[i]}");
                }
            }

            if (returnValue.Length == 0)
                return returnValue;

            return returnValue.Substring(seperator.Length);
        }

        public static string Decode(string Input, Dictionary<string, string> keys, string ProgressBarName, string splitter = "")
        {
            return Encode(Input, keys.FlipDict(), ProgressBarName, "", splitter);
        }

        public static string Repeat(string Input, int amount, bool encode)
        {
            if (!encode)
            {
                new ProgressBar("Repeat Backwards", 1, 1).Print();
                return Input.Substring(0, Input.Length / amount);
            }
            ProgressBar bar = new ProgressBar("Repeat", amount);

            string returnValue = "";

            for (int i = 0; i < amount; i++)
            {
                returnValue += Input;
                bar.Increase();
            }

            return returnValue;
        }
    }
}
