using System;
using System.Threading;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{
    public static class GTranslator
    {
		public static Dictionary<string, string> getLanguage = new()
		{
			{ "detectlanguage", "auto" },
			{ "afrikaans", "af" },
			{ "albanian", "sq" },
			{ "amharic", "am" },
			{ "arabic", "ar" },
			{ "armenian", "hy" },
			{ "azerbaijani", "az" },
			{ "basque", "eu" },
			{ "belarusian", "be" },
			{ "bengali", "bn" },
			{ "bosnian", "bs" },
			{ "bulgarian", "bg" },
			{ "catalan", "ca" },
			{ "cebuano	", "eb" },
			{ "Chinesesimplified", "zh-CN" },
			{ "Chinesetraditional", "zh-TW" },
			{ "corsican", "co" },
			{ "croatian", "hr" },
			{ "czech", "cs" },
			{ "danish", "da" },
			{ "dutch", "nl" },
			{ "english", "en" },
			{ "esperanto", "eo" },
			{ "estonian", "et" },
			{ "finnish", "fi" },
			{ "french", "fr" },
			{ "frisian", "fy" },
			{ "galician", "gl" },
			{ "georgian", "ka" },
			{ "german", "de" },
			{ "greek", "el" },
			{ "gujarati", "gu" },
			{ "haitian creole", "ht" },
			{ "hausa", "ha" },
			{ "hawaiian", "haw" },
			{ "hebrew", "he" },
			{ "hindi", "hi" },
			{ "hmong", "hmn" },
			{ "hungarian", "hu" },
			{ "icelandic", "is" },
			{ "igbo", "ig" },
			{ "indonesian", "id" },
			{ "irish", "ga" },
			{ "italian", "it" },
			{ "japanese", "ja" },
			{ "javanese", "jv" },
			{ "kannada", "kn" },
			{ "kazakh", "kk" },
			{ "khmer", "km" },
			{ "kinyarwanda", "rw" },
			{ "korean", "ko" },
			{ "kurdish", "ku" },
			{ "kyrgyz", "ky" },
			{ "lao", "lo" },
			{ "latvian", "lv" },
			{ "lithuanian", "lt" },
			{ "luxembourgish", "lb" },
			{ "macedonian", "mk" },
			{ "malagasy", "mg" },
			{ "malay", "ms" },
			{ "malayalam", "ml" },
			{ "maltese", "mt" },
			{ "maori", "mi" },
			{ "marathi", "mr" },
			{ "mongolian", "mn" },
			{ "myanmar", "my" },
			{ "burmese", "my" },
			{ "nepali", "ne" },
			{ "norwegian", "no" },
			{ "nyanja ", "ny" },
			{ "chichewa", "ny" },
			{ "odia ", "or" },
			{ "oriya", "or" },
			{ "pashto", "ps" },
			{ "persian", "fa" },
			{ "polish", "pl" },
			{ "portuguese", "pt" },
			{ "punjabi", "pa" },
			{ "romanian", "ro" },
			{ "russian", "ru" },
			{ "samoan", "sm" },
			{ "scots gaelic", "gd" },
			{ "serbian", "sr" },
			{ "sesotho", "st" },
			{ "shona", "sn" },
			{ "sindhi", "sd" },
			{ "sinhala", "si" },
			{ "sinhalese", "si" },
			{ "slovak", "sk" },
			{ "slovenian", "sl" },
			{ "somali", "so" },
			{ "spanish", "es" },
			{ "sundanese", "su" },
			{ "swahili", "sw" },
			{ "swedish", "sv" },
			{ "tagalog", "tl" },
			{ "filipino", "tl" },
			{ "tajik", "tg" },
			{ "tamil", "ta" },
			{ "tatar", "tt" },
			{ "telugu", "te" },
			{ "thai", "th" },
			{ "turkish", "tr" },
			{ "turkmen", "tk" },
			{ "ukrainian", "uk" },
			{ "urdu", "ur" },
			{ "uyghur", "ug" },
			{ "uzbek", "uz" },
			{ "vietnamese", "vi" },
			{ "welsh", "cy" },
			{ "xhosa", "xh" },
			{ "yiddish", "yi" },
			{ "yoruba", "yo" },
			{ "zulu", "zu" },
		};
		public static string Translate(string word, string fromLanguage, string toLanguage, bool progressbar = true)
		{
			ProgressBar bar = null;
			if (progressbar)
				bar = new ProgressBar($"Translate from {fromLanguage} to {toLanguage}", 4);

			fromLanguage = fromLanguage.ToLower().Trim();
			toLanguage = toLanguage.ToLower().Trim();

			if (getLanguage.ContainsKey(fromLanguage))
				fromLanguage = getLanguage[fromLanguage];

			if (getLanguage.ContainsKey(toLanguage))
				toLanguage = getLanguage[toLanguage];

			if (progressbar)
				bar.Increase();

			var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
			var webClient = new WebClient
			{
				Encoding = Encoding.UTF8
			};

			if (progressbar)
				bar.Increase();

			var result = "";
            try
            {
				result = webClient.DownloadString(url);

				if (progressbar)
					bar.Increase();
            }
            catch (WebException exc)
            {
				if (exc.Message.Contains("(400)"))
					Program.Error($"There was an error translating the languages {fromLanguage} or {toLanguage}");

				else if (exc.Message.Contains("(429)"))
                {
					Program.Error("Too many google translate requests. Chill out");

					if (progressbar)
						return word;

					return "__too many requests__";
                }

				else
					Program.Error($"Error reaching translate.googleapis.com. ({exc.Message})");

				if (progressbar)
					bar.Increase(2);

				return word;
            }

			if (progressbar)
				bar.Increase();

			try
			{
				result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
				return result;
			}
			catch (Exception exc)
			{
				Program.Error($"Language: {exc.Message}");
				return word;
			}
		}

		public static string Nonsense(string input)
        {
			string[] lines = new string[]
			{
				"es",
				"am",
				"fr",
				"nl",
				"en",
				"ar",
				"en",
				"zh-CN",
				"bg",
				"cs",
				"zu",
				"am",
				"ar",
				"az",
				"en",
				"eu",
				"es",
				"zh-CN",
				"en",
				"es",
				"da",
				"es",
				"et",
				"sv",
				"el",
				"iw",
				"cy",
				"ja",
				"da",
				"hr",
				"az",
				"vi",
				"th",
				"ja",
				"ru",
				"gd",
				"en",
			};
			ProgressBar bar = new ProgressBar($"Nonsensify", lines.Length);

			string returnVal = input;
            for (int i = 0; i < lines.Length; i++)
            {
				string translateResult;
				if (i == 0)
					translateResult = Translate(returnVal, "auto", lines[i], false);
				else
					translateResult = Translate(returnVal, lines[i], lines[i - 1], false);

				if (translateResult == "__too many requests__")
				{
					Program.Error("Nonsensify failed. too many requests");
					return input;
				}
				else
					returnVal = translateResult;

				bar.Increase();
			}

			return returnVal;
        }
	}
}