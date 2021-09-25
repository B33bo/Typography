using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Typography
{
    public static class Upsidedown
    {
        public static Dictionary<string, string> alphabet = new()
        {
            {"A", "∀"},
            {"∀", "A"},
            {"a", "ɐ"},
            {"ɐ", "a"},
            {"B", "q"},
            {"b", "p"},
            {"q", "b"},
            {"p", "b"},
            {"e", "ǝ"},
            {"ǝ", "e"},
            {"h", "ɥ"},
            {"ɥ", "h"},
            {"i", "ı"},
            {"ı", "i"},
            {"J", "ſ"},
            {"ſ", "J"},
            {"j", "ɾ"},
            {"ɾ", "j"},
            {"K", "ʞ"},
            {"ʞ", "K"},
            {"k", "ʞ"},
            {"L", "˥"},
            {"˥", "L"},
            {"l", "ן"},
            {"ן", "l"},
            {"M", "W"},
            {"m", "w"},
            {"P", "D"},
            {"D", "P"},
            {"Ὁ", "Q"},
            {"d", "q"},
            {"R", "ᴚ"},
            {"ᴚ", "R"},
            {"r", "ɹ"},
            {"ɹ", "r"},
            {"T", "⊥"},
            {"⊥", "T"},
            {"t", "ʇ"},
            {"ʇ", "t"},
            {"U", "∩"},
            {"∩", "U"},
            {"u", "n"},
            {"n", "u"},
            {"V", "Λ"},
            {"Λ", "V"},
            {"v", "ʌ"},
            {"ʌ", "v"},
            {"W", "M"},
            {"w", "m"},
            {"Y", "ʎ"},
            {"y", "ʎ"},
            {"ʎ", "y"},
            {"!", "¡"},
            {"¡", "!"},
            {"\"", "„"},
            {"„", "\""},
            {"_", "‾"},
            {"‾", "_"},
            {"'", ","},
            {",", "'"},
            {";", "؛"},
            {"؛", ";"},
            {".", "˙"},
            {"˙", "."},
            {"?", "¿"},
            {"¿", "?"},
            {"1", "l"},
            {"2", "ᄅ"},
            {"ᄅ", "2"},
            {"3", "Ɛ"},
            {"Ɛ", "3"},
            {"4", "ㄣ"},
            {"ㄣ", "4"},
            {"5", "ϛ"},
            {"6", "9"},
            {"ϛ", "5"},
            {"7", "ㄥ"},
            {"ㄥ", "7"},
            {"9", "6"},
        };

        public static string Upsideown(string input)
        {
            ProgressBar bar = new("Upsidedown", input.Length);
            string returnValue = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (alphabet.ContainsKey(input[i].ToString()))
                    returnValue += alphabet[input[i].ToString()];

                else if (alphabet.ContainsKey(input[i].ToString().ToLower()))
                    returnValue += alphabet[input[i].ToString().ToLower()];

                else
                    returnValue += input[i];

                bar.Increase();
            }

            return returnValue;
        }
    }
}
