using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Typography.Meta;
using System.Threading.Tasks;

namespace Typography
{
    //Credit: https://htwins.net/unicrush/
    public static class Crush
    {
        public static uint highestLength = 0;
        public static Dictionary<string, string> normal = new()
        {
            {"<<", "«"},
            {">>", "»"},
            {"1/4", "¼"},
            {"1/2", "½"},
            {"3/4", "¾"},
            {"AE", "Æ"},
            {"ae", "æ"},
            {"IJ", "Ĳ"},
            {"ij", "ĳ"},
            {"L'", "Ľ"},
            {"l'", "ľ"},
            {"OE", "Œ"},
            {"oe", "œ"},
            {"t'", "ť"},
            {"O'", "Ơ"},
            {"o'", "ơ"},
            {"'P", "Ƥ"},
            {"U'", "Ư"},
            {"u'", "ư"},
            {"||", "ǁ"},
            {"LJ", "Ǉ"},
            {"Lj", "ǈ"},
            {"lj", "ǉ"},
            {"NJ", "Ǌ"},
            {"Nj", "ǋ"},
            {"nj", "ǌ"},
            {"DZ", "Ǳ"},
            {"Dz", "ǲ"},
            {"dz", "ǳ"},
            {"ts", "ʦ"},
            {"ls", "ʪ"},
            {"lz", "ʫ"},
            {"\"A", "Ἃ"},
            {"\"E", "Ἓ"},
            {"\"H", "Ἣ"},
            {"\"I", "Ἳ"},
            {"\"O", "Ὃ"},
            {"\"Y", "Ὓ"},
            {"bI", "Ы"},
            {"Oy", "Ѹ"},
            {"oy", "ѹ"},
            {"ue", "ᵫ"},
            {"0/00", "‰"},
            {"0/000", "‱"},
            {"!!", "‼"},
            {"/,", "⁁"},
            {"??", "⁇"},
            {"?!", "⁈"},
            {"!?", "⁉"},
            {"Pts", "₧"},
            {"Rs", "₨"},
            {"Dp", "₯"},
            {"°C", "℃"},
            {"°F", "℉"},
            {"No", "№"},
            {"Px", "℞"},
            {"SM", "℠"},
            {"TEL", "℡"},
            {"TM", "™"},
            {"1/3", "⅓"},
            {"2/3", "⅔"},
            {"1/5", "⅕"},
            {"2/5", "⅖"},
            {"3/5", "⅗"},
            {"4/5", "⅘"},
            {"1/6", "⅙"},
            {"5/6", "⅚"},
            {"1/8", "⅛"},
            {"3/8", "⅜"},
            {"5/8", "⅝"},
            {"7/8", "⅞"},
            {"1/", "⅟"},
            {"II", "Ⅱ"},
            {"III", "Ⅲ"},
            {"IV", "Ⅳ"},
            {"VI", "Ⅵ"},
            {"VII", "Ⅶ"},
            {"VIII", "Ⅷ"},
            {"IX", "Ⅸ"},
            {"XI", "Ⅺ"},
            {"XII", "Ⅻ"},
            {"ii", "ⅱ"},
            {"iii", "ⅲ"},
            {"iv", "ⅳ"},
            {"vi", "ⅵ"},
            {"vii", "ⅶ"},
            {"viii", "ⅷ"},
            {"ix", "ⅸ"},
            {"xi", "ⅺ"},
            {"xii", "ⅻ"},
            {"=/=", "≠"},
            {"<=", "≤"},
            {">=", "≥"},
            {"()", "≬"},
            {"<<<", "⋘"},
            {">>>", "⋙"},
            {"NUL", "␀"},
            {"SOH", "␁"},
            {"STX", "␂"},
            {"EXT", "␃"},
            {"EOT", "␄"},
            {"ENQ", "␅"},
            {"ACK", "␆"},
            {"BEL", "␇"},
            {"BS", "␈"},
            {"HT", "␉"},
            {"LF", "␊"},
            {"VT", "␋"},
            {"FF", "␌"},
            {"CR", "␍"},
            {"SO", "␎"},
            {"SI", "␏"},
            {"DLE", "␐"},
            {"DC1", "␑"},
            {"DC2", "␒"},
            {"DC3", "␓"},
            {"DC4", "␔"},
            {"NAK", "␕"},
            {"SYN", "␖"},
            {"ETB", "␗"},
            {"CAN", "␘"},
            {"EM", "␙"},
            {"SUB", "␚"},
            {"ESC", "␛"},
            {"FS", "␜"},
            {"GS", "␝"},
            {"RS", "␞"},
            {"US", "␟"},
            {"SP", "␠"},
            {"DEL", "␡"},
            {"NL", "␤"},
            {"\\\\", "⑊"},
            {"(1)", "⑴"},
            {"(2)", "⑵"},
            {"(3)", "⑶"},
            {"(4)", "⑷"},
            {"(5)", "⑸"},
            {"(6)", "⑹"},
            {"(7)", "⑺"},
            {"(8)", "⑻"},
            {"(9)", "⑼"},
            {"(10)", "⑽"},
            {"(11)", "⑾"},
            {"(12)", "⑿"},
            {"(13)", "⒀"},
            {"(14)", "⒁"},
            {"(15)", "⒂"},
            {"(16)", "⒃"},
            {"(17)", "⒄"},
            {"(18)", "⒅"},
            {"(19)", "⒆"},
            {"(20)", "⒇"},
            {"1.", "⒈"},
            {"2.", "⒉"},
            {"3.", "⒊"},
            {"4.", "⒋"},
            {"5.", "⒌"},
            {"6.", "⒍"},
            {"7.", "⒎"},
            {"8.", "⒏"},
            {"9.", "⒐"},
            {"10.", "⒑"},
            {"11.", "⒒"},
            {"12.", "⒓"},
            {"13.", "⒔"},
            {"14.", "⒕"},
            {"15.", "⒖"},
            {"16.", "⒗"},
            {"17.", "⒘"},
            {"18.", "⒙"},
            {"19.", "⒚"},
            {"20.", "⒛"},
            {"(a)", "⒜"},
            {"(b)", "⒝"},
            {"(c)", "⒞"},
            {"(d)", "⒟"},
            {"(e)", "⒠"},
            {"(f)", "⒡"},
            {"(g)", "⒢"},
            {"(h)", "⒣"},
            {"(i)", "⒤"},
            {"(j)", "⒥"},
            {"(k)", "⒦"},
            {"(l)", "⒧"},
            {"(m)", "⒨"},
            {"(n)", "⒩"},
            {"(o)", "⒪"},
            {"(p)", "⒫"},
            {"(q)", "⒬"},
            {"(r)", "⒭"},
            {"(s)", "⒮"},
            {"(t)", "⒯"},
            {"(u)", "⒰"},
            {"(v)", "⒱"},
            {"(w)", "⒲"},
            {"(x)", "⒳"},
            {"(y)", "⒴"},
            {"(z)", "⒵"},
            {"hPa", "㍱"},
            {"da", "㍲"},
            {"AU", "㍳"},
            {"bar", "㍴"},
            {"oV", "㍵"},
            {"pc", "㍶"},
            {"pA", "㎀"},
            {"nA", "㎁"},
            {"mA", "㎃"},
            {"kA", "㎄"},
            {"KB", "㎅"},
            {"MB", "㎆"},
            {"GB", "㎇"},
            {"cal", "㎈"},
            {"kcal", "㎉"},
            {"pF", "㎊"},
            {"nF", "㎋"},
            {"mg", "㎎"},
            {"kg", "㎏"},
            {"Hz", "㎐"},
            {"kHz", "㎑"},
            {"MHz", "㎒"},
            {"GHz", "㎓"},
            {"THz", "㎔"},
            {"fm", "㎙"},
            {"nm", "㎚"},
            {"mm", "㎜"},
            {"cm", "㎝"},
            {"km", "㎞"},
            {"m/s", "㎧"},
            {"Pa", "㎩"},
            {"kPa", "㎪"},
            {"MPa", "㎫"},
            {"GPA", "㎬"},
            {"rad", "㎭"},
            {"rad/s", "㎮"},
            {"ps", "㎰"},
            {"ns", "㎱"},
            {"ms", "㎳"},
            {"pV", "㎴"},
            {"nV", "㎵"},
            {"mV", "㎷"},
            {"kV", "㎸"},
            {"MV", "㎹"},
            {"pW", "㎺"},
            {"nW", "㎻"},
            {"mW", "㎽"},
            {"kW", "㎾"},
            {"MW", "㎿"},
            {"a.m.", "㏂"},
            {"Bq", "㏃"},
            {"cc", "㏄"},
            {"cd", "㏅"},
            {"C/kg", "㏆"},
            {"Co.", "㏇"},
            {"dB", "㏈"},
            {"Gy", "㏉"},
            {"ha", "㏊"},
            {"HP", "㏋"},
            {"in", "㏌"},
            {"KK", "㏍"},
            {"KM", "㏎"},
            {"kt", "㏏"},
            {"lm", "㏐"},
            {"ln", "㏑"},
            {"log", "㏒"},
            {"lx", "㏓"},
            {"mb", "㏔"},
            {"mil", "㏕"},
            {"mol", "㏖"},
            {"pH", "㏗"},
            {"p.m.", "㏘"},
            {"PPM", "㏙"},
            {"PR", "㏚"},
            {"sr", "㏛"},
            {"Sv", "㏜"},
            {"Wb", "㏝"},
        };

        public static Dictionary<string, string> iffy = new()
        {
            {"hu", "ƕ"},
            {"Hu", "Ƕ"},
            {"db", "ȸ"},
            {"cb", "ȸ"},
            {"qp", "ȹ"},
            {"cp", "ȹ"},
            {"l3", "ɮ"},
            {"d3", "ʤ"},
            {"WW", "ʬ"},
            {"Hb", "Њ"},
            {"IO", "Ю"},
            {"bi", "ы"},
            {"io", "ю"},
            {"IA", "Ѩ"},
            {"X,", "Ӽ"},
            {"x,", "ӽ"},
            {"du", "ԃ"},
            {"Tu", "Ԏ"},
            {"th", "ᵺ"},
            {"***", "⁂"},
            {"**", "⁑"},
            {"CE", "₠"},
            {"a/c", "℀"},
            {"a/s", "℁"},
            {"c/o", "℅"},
            {"c/u", "℆"},
            {"ff", "∬"},
            {"fff", "∭"},
        };

        private static uint GetHighestLength()
        {
            uint currentHiVal = 0;

            foreach (string item in normal.Keys)
            {
                if (item.Length > currentHiVal)
                    currentHiVal = (uint)item.Length;
            }

            foreach (string item in iffy.Keys)
            {
                if (item.Length > currentHiVal)
                    currentHiVal = (uint)item.Length;
            }

            return currentHiVal;
        }

        public static string Encode(string input, bool AllowIffy = true)
        {
            ProgressBar bar = new("Unicrush", input.Length);
            if (highestLength == 0)
                highestLength = GetHighestLength();

            string returnVal = "";

            for (int i = 0; i < input.Length; i++)
            {
                bar.Increase();
                string futureChars = "";

                //Looks into the future for the next chars
                /*
				 * Uses highestLength+1 and then checks if the future index = highestLenght+1
				 *To detect if it never found anything
				 */

                for (int futureIndex = 0; futureIndex < highestLength + 1; futureIndex++)
                {
                    if (futureIndex == highestLength)
                    {
                        //Never finds anything
                        returnVal += input[i];
                        break;
                    }

                    if (input.Length <= i + futureIndex)
                    {
                        //The future index is > than the input
                        returnVal += input[i];
                        break;
                    }

                    //Appends the current future chars to a variable
                    futureChars += input[i + futureIndex];

                    if (normal.ContainsKey(futureChars))
                    {
                        returnVal += normal[futureChars];
                        i += futureIndex;
                        bar.Increase(futureIndex);
                        break;
                    }

                    if (AllowIffy && iffy.ContainsKey(futureChars))
                    {
                        returnVal += iffy[futureChars];
                        bar.Increase(futureIndex);
                        i += futureIndex;
                        break;
                    }
                }
            }

            return returnVal;
        }

        public static string Decode(string input)
        {
            ProgressBar bar = new("Crush Decode", input.Length);

            Dictionary<string, string> backwardsNormal = normal.FlipDict();
            Dictionary<string, string> backwardsIffy = iffy.FlipDict();

            string returnVal = "";
            for (int i = 0; i < input.Length; i++)
            {
                bar.Increase();

                string currentChar = input[i].ToString();

                if (backwardsNormal.ContainsKey(currentChar))
                    returnVal += backwardsNormal[currentChar];

                else if (backwardsIffy.ContainsKey(currentChar))
                    returnVal += backwardsIffy[currentChar];

                else
                    returnVal += currentChar;
            }

            return returnVal;
        }
    }
}
