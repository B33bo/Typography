using System;
using System.Linq;
using System.Collections.Generic;
using Typography;

namespace Typography
{
    public static class PeriodicTable
    {
        public static Dictionary<string, string> keys = new Dictionary<string, string>()
        {
			{"h", "hydrogen"},
			{"li", "lithium"},
			{"na", "sodium"},
			{"k", "potassium"},
			{"rb", "rubidium"},
			{"cs", "cesium"},
			{"fr", "francium"},
			{"be", "beryllium"},
			{"mg", "magnesium"},
			{"ca", "calcium"},
			{"sr", "strontium"},
			{"ba", "barium"},
			{"ra", "radium"},
			{"sc", "scandium"},
			{"y", "yttrium"},
			{"ti", "titanium"},
			{"zr", "zirconium"},
			{"hf", "hafnium"},
			{"rf", "rutherfordium"},
			{"la", "lanthanum"},
			{"ac", "acrinium"},
			{"v", "vanadium"},
			{"nb", "niobium"},
			{"ta", "tantalum"},
			{"db", "dubnium"},
			{"ce", "cerium"},
			{"th", "thorium"},
			{"cr", "chromium"},
			{"mo", "molybdenum"},
			{"w", "tungsten"},
			{"sg", "seaborgium"},
			{"pr", "praseodymium"},
			{"pa", "protactinium"},
			{"mn", "manganese"},
			{"tc", "technetium"},
			{"re", "rthenium"},
			{"bh", "bohrium"},
			{"nd", "neodymium"},
			{"u", "uranium"},
			{"fe", "iron"},
			{"ru", "ruthenium"},
			{"os", "osmium"},
			{"hs", "hassium"},
			{"pm", "promethium"},
			{"np", "neptunium"},
			{"co", "cobalt"},
			{"rh", "rhodium"},
			{"ir", "iridium"},
			{"mt", "meitnerium"},
			{"sm", "samarium"},
			{"pu", "plutonium"},
			{"ni", "nickel"},
			{"pd", "palladium"},
			{"pt", "platinum"},
			{"ss", "darmstadtium"},
			{"eu", "europium"},
			{"am", "americium"},
			{"cu", "copper"},
			{"ag", "silver"},
			{"au", "gold"},
			{"rg", "roentgenium"},
			{"gd", "gadolinium"},
			{"cm", "curium"},
			{"zn", "zinc"},
			{"cd", "cadmium"},
			{"hg", "mercury"},
			{"cn", "copernicium"},
			{"tb", "terbium"},
			{"bk", "berkellium"},
			{"b" , "boron"},
			{"al", "aluminum"},
			{"ga", "gallium"},
			{"in", "indium"},
			{"tl", "thallium"},
			{"uut", "ununtrium"},
			{"dy", "dysprosium"},
			{"cf", "californium"},
			{"c", "carbon"},
			{"si", "silicon"},
			{"ge", "germanium"},
			{"sn", "tin"},
			{"pb", "lead"},
			{"fl", "flerovium"},
			{"ho", "holmium"},
			{"es", "einsteinium"},
			{"n", "nitrogen"},
			{"p", "phosphorous"},
			{"as", "arsenic"},
			{"sb", "antimony"},
			{"bi", "bismuth"},
			{"uup", "unenpentium"},
			{"er", "erbium"},
			{"fm", "fermium"},
			{"o", "oxygen"},
			{"s", "sulfur"},
			{"se", "selenium"},
			{"te", "tellurlum"},
			{"po", "polonium"},
			{"lv", "livermorium"},
			{"tm", "thulium"},
			{"md", "mendelevium"},
			{"f", "florine"},
			{"cl", "chlorine"},
			{"br", "bromine"},
			{"i", "iodine"},
			{"at", "astatine"},
			{"uus", "ununseptium"},
			{"yb", "ytterbium"},
			{"no", "nobelium"},
			{"he", "helium"},
			{"ne", "neon"},
			{"ar", "argon"},
			{"kr", "krypton"},
			{"xe", "xenon"},
			{"rn", "radon"},
			{"uuo", "ununoctium"},
			{"lu", "lutetium"},
			{"lr", "lawrencium"},
		};

        public static string Encode(string Input)
        {
			ProgressBar bar = new ProgressBar("Periodic table (Encode)", Input.Length);
            string returnValue = "";
            for (int i = 0; i < Input.Length; i++)
            {
				bar.Increase();
                if (i + 1 != Input.Length) // 'i' is not at the very end of the string
                {
                    string next2Letters = Input[i] + Input[i + 1].ToString();
                    next2Letters = next2Letters.ToLower().Trim();

                    if (keys.ContainsKey(next2Letters)) //If the character + the next character exists
                    {
                        returnValue += keys[next2Letters] + " "; //Use it
						bar.Increase();
                        i++; //Skip second char
                        continue;
                    }
                }

                if (keys.ContainsKey(Input[i].ToString()))
                {
                    returnValue += keys[Input[i].ToString()] + " "; //If the character exists, just use it
                    continue;
                }

				Program.Error($"Periodic table:: No word for letter {Input[i]}. Ignoring Letter");
            }

            return returnValue;
        }

        public static string Decode(string Input)
        {
			Dictionary<string, string> flippedElements = keys.FlipDict();
			string[] inputElements = Input.ToLower().Split(' ');
			string returnValue = "";

			ProgressBar bar = new ProgressBar("Periodic table (Decode)", inputElements.Length);
            foreach (string item in inputElements)
            {
				if (flippedElements.ContainsKey(item))
					returnValue += $" {flippedElements[item]}";
				else if (item == "" || item == "\n" || item == "\r" || item == " ")
					continue;
				else
					Program.Error($"Periodic table:: No periodic table character for {item}");

				bar.Increase();
            }

			if (returnValue.Length <= 1)
				return "";
			//Apparantly this is the same as returnValue.substring(1) and that is the coolest thing in the world
			//Oh yeah and it substrings at one because it always starts with a space unless you do that
			return returnValue[1..];
        }
    }
}
