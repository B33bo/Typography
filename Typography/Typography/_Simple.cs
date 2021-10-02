﻿using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Typography
{
    public static class TextToEncode
    {
        public static Dictionary<string, string> blackBubbleText = new()
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

        public static Dictionary<string, string> BubbleText = new()
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

        public static Dictionary<string, string> oldSchool = new()
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

        public static Dictionary<string, string> doubleStruck = new()
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

        public static Dictionary<string, string> discordEmoji = new()
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

        public static Dictionary<string, string> morseCode = new()
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

        public static Dictionary<string, string> bold = new()
        {
            {"A", "𝐀"},
            {"a", "𝐚"},
            {"B", "𝐁"},
            {"b", "𝐛"},
            {"C", "𝐂"},
            {"c", "𝐜"},
            {"D", "𝐃"},
            {"d", "𝐝"},
            {"E", "𝐄"},
            {"e", "𝐞"},
            {"F", "𝐅"},
            {"f", "𝐟"},
            {"G", "𝐆"},
            {"g", "𝐠"},
            {"H", "𝐇"},
            {"h", "𝐡"},
            {"I", "𝐈"},
            {"i", "𝐢"},
            {"J", "𝐉"},
            {"j", "𝐣"},
            {"K", "𝐊"},
            {"k", "𝐤"},
            {"L", "𝐋"},
            {"l", "𝐥"},
            {"M", "𝐌"},
            {"m", "𝐦"},
            {"N", "𝐍"},
            {"n", "𝐧"},
            {"O", "𝐎"},
            {"o", "𝐨"},
            {"P", "𝐏"},
            {"p", "𝐩"},
            {"Q", "𝐐"},
            {"q", "𝐪"},
            {"R", "𝐑"},
            {"r", "𝐫"},
            {"S", "𝐒"},
            {"s", "𝐬"},
            {"T", "𝐓"},
            {"t", "𝐭"},
            {"U", "𝐔"},
            {"u", "𝐮"},
            {"V", "𝐕"},
            {"v", "𝐯"},
            {"W", "𝐖"},
            {"w", "𝐰"},
            {"X", "𝐗"},
            {"x", "𝐱"},
            {"Y", "𝐘"},
            {"y", "𝐲"},
            {"Z", "𝐙"},
            {"z", "𝐳"},
            {"1", "𝟏"},
            {"2", "𝟐"},
            {"3", "𝟑"},
            {"4", "𝟒"},
            {"5", "𝟓"},
            {"6", "𝟔"},
            {"7", "𝟕"},
            {"8", "𝟖"},
            {"9", "𝟗"},
            {"0", "𝟎"},
        };

        public static Dictionary<string, string> italics = new()
        {
            {"A", "𝐴"},
            {"a", "𝑎"},
            {"B", "𝐵"},
            {"b", "𝑏"},
            {"C", "𝐶"},
            {"c", "𝑐"},
            {"D", "𝐷"},
            {"d", "𝑑"},
            {"E", "𝐸"},
            {"e", "𝑒"},
            {"F", "𝐹"},
            {"f", "𝑓"},
            {"G", "𝐺"},
            {"g", "𝑔"},
            {"H", "𝐻"},
            {"h", "ℎ"},
            {"I", "𝐼"},
            {"i", "𝑖"},
            {"J", "𝐽"},
            {"j", "𝑗"},
            {"K", "𝐾"},
            {"k", "𝑘"},
            {"L", "𝐿"},
            {"l", "𝑙"},
            {"M", "𝑀"},
            {"m", "𝑚"},
            {"N", "𝑁"},
            {"n", "𝑛"},
            {"O", "𝑂"},
            {"o", "𝑜"},
            {"P", "𝑃"},
            {"p", "𝑝"},
            {"Q", "𝑄"},
            {"q", "𝑞"},
            {"R", "𝑅"},
            {"r", "𝑟"},
            {"S", "𝑆"},
            {"s", "𝑠"},
            {"T", "𝑇"},
            {"t", "𝑡"},
            {"U", "𝑈"},
            {"u", "𝑢"},
            {"V", "𝑉"},
            {"v", "𝑣"},
            {"W", "𝑊"},
            {"w", "𝑤"},
            {"X", "𝑋"},
            {"x", "𝑥"},
            {"Y", "𝑌"},
            {"y", "𝑦"},
            {"Z", "𝑍"},
            {"z", "𝑧"},
        };

        public static Dictionary<string, string> boldItalics = new()
        {
            {"A", "𝑨"},
            {"a", "𝒂"},
            {"B", "𝑩"},
            {"b", "𝒃"},
            {"C", "𝑪"},
            {"c", "𝒄"},
            {"D", "𝑫"},
            {"d", "𝒅"},
            {"E", "𝑬"},
            {"e", "𝒆"},
            {"F", "𝑭"},
            {"f", "𝒇"},
            {"G", "𝑮"},
            {"g", "𝒈"},
            {"H", "𝑯"},
            {"h", "𝒉"},
            {"I", "𝑰"},
            {"i", "𝒊"},
            {"J", "𝑱"},
            {"j", "𝒋"},
            {"K", "𝑲"},
            {"k", "𝒌"},
            {"L", "𝑳"},
            {"l", "𝒍"},
            {"M", "𝑴"},
            {"m", "𝒎"},
            {"N", "𝑵"},
            {"n", "𝒏"},
            {"O", "𝑶"},
            {"o", "𝒐"},
            {"P", "𝑷"},
            {"p", "𝒑"},
            {"Q", "𝑸"},
            {"q", "𝒒"},
            {"R", "𝑹"},
            {"r", "𝒓"},
            {"S", "𝑺"},
            {"s", "𝒔"},
            {"T", "𝑻"},
            {"t", "𝒕"},
            {"U", "𝑼"},
            {"u", "𝒖"},
            {"V", "𝑽"},
            {"v", "𝒗"},
            {"W", "𝑾"},
            {"w", "𝒘"},
            {"X", "𝑿"},
            {"x", "𝒙"},
            {"Y", "𝒀"},
            {"y", "𝒚"},
            {"Z", "𝒁"},
            {"z", "𝒛"},
        };

        public static Dictionary<string, string> smallcaps = new()
        {   
            {"a", "ᴀ"},
            {"b", "ʙ"},
            {"c", "ᴄ"},
            {"d", "ᴅ"},
            {"e", "ᴇ"},
            {"f", "ꜰ"},
            {"g", "ɢ"},
            {"h", "ʜ"},
            {"i", "ɪ"},
            {"j", "ᴊ"},
            {"k", "ᴋ"},
            {"l", "ʟ"},
            {"m", "ᴍ"},
            {"n", "ɴ"},
            {"o", "ᴏ"},
            {"p", "ᴘ"},
            {"q", "Q"},
            {"r", "ʀ"},
            {"s", "ꜱ"},
            {"t", "ᴛ"},
            {"u", "ᴜ"},
            {"v", "ᴠ"},
            {"w", "ᴡ"},
            {"x", "X"},
            {"y", "ʏ"},
            {"z", "ᴢ"},
        };

        public static Dictionary<string, string> textToHtml = new()
        {
            {"\"", "&quot;"},
            {"'", "&apos;"},
            {"&", "&amp;"},
            {"<", "&lt;	l"},
            {">", "&gt;"},
            {" ", "&nbsp;"},
            {"¡", "&iexcl;"},
            {"£", "&pound"},
            {"¢", "&cent;"},
            {"¤", "&curren;"},
            {"¥", "&yen;"},
            {"¦", "&brvbar;"},
            {"§", "&sect;"},
            {"¨", "&uml;"},
            {"©", "&copy;"},
            {"ª", "&ordf;"},
            {"«", "&laquo;"},
            {"¬", "&not;"},
            {"­", "&shy;"},
            {"®", "&reg;"},
            {"¯", "&macr;"},
            {"°", "&deg;"},
            {"±", "&plusmn;"},
            {"²", "&sup2;"},
            {"³", "&sup3;"},
            {"´", "&acute;"},
            {"µ", "&micro;"},
            {"¶", "&para;"},
            {"·", "&middot;"},
            {"¸", "&cedil;"},
            {"¹", "&sup1;"},
            {"º", "&ordm;"},
            {"»", "&raquo;"},
            {"¼", "&frac14;"},
            {"½", "&frac12;"},
            {"¾", "&frac34;"},
            {"¿", "&iquest;"},
            {"×", "&times;"},
            {"÷", "&divide;"},
            {"À", "&Agrave;"},
            {"Á", "&Aacute;"},
            {"Â", "&Acirc;"},
            {"Ã", "&Atilde;"},
            {"Ä", "&Auml;"},
            {"Å", "&Aring;"},
            {"Æ", "&AElig;"},
            {"Ç", "&Ccedil;"},
            {"È", "&Egrave;"},
            {"É", "&Eacute;"},
            {"Ê", "&Ecirc;"},
            {"Ë", "&Euml;"},
            {"Ì", "&Igrave;"},
            {"Í", "&Iacute;"},
            {"Î", "&Icirc;"},
            {"Ï", "&Iuml;"},
            {"Ð", "&ETH;"},
            {"Ñ", "&Ntilde;"},
            {"Ò", "&Ograve;"},
            {"Ó", "&Oacute;"},
            {"Ô", "&Ocirc;"},
            {"Õ", "&Otilde;"},
            {"Ö", "&Ouml;"},
            {"Ø", "&Oslash;"},
            {"Ù", "&Ugrave;"},
            {"Ú", "&Uacute;"},
            {"Û", "&Ucirc;"},
            {"Ü", "&Uuml;"},
            {"Ý", "&Yacute;"},
            {"Þ", "&THORN;"},
            {"ß", "&szlig;"},
            {"à", "&agrave;"},
            {"á", "&aacute;"},
            {"â", "&acirc;"},
            {"ã", "&atilde;"},
            {"ä", "&auml;"},
            {"å", "&aring;"},
            {"æ", "&aelig;"},
            {"ç", "&ccedil;"},
            {"è", "&egrave;"},
            {"é", "&eacute;"},
            {"ê", "&ecirc;"},
            {"ë", "&euml;"},
            {"ì", "&igrave;"},
            {"í", "&iacute;"},
            {"î", "&icirc;"},
            {"ï", "&iuml;"},
            {"ð", "&eth;"},
            {"ñ", "&ntilde;"},
            {"ò", "&ograve;"},
            {"ó", "&oacute;"},
            {"ô", "&ocirc;"},
            {"õ", "&otilde;"},
            {"ö", "&ouml;"},
            {"ø", "&oslash;"},
            {"ù", "&ugrave;"},
            {"ú", "&uacute;"},
            {"û", "&ucirc;"},
            {"ü", "&uuml;"},
            {"ý", "&yacute;"},
            {"þ", "&thorn;"},
            {"ÿ", "&yuml;"},
        };

        public static Dictionary<string, string> leetSpeak = new()
        {
            {"a", "4"},
            {"b", "8"},
            {"e", "3"},
            {"g", "9"},
            {"i", "1"},
            {"l", "1"},
            {"o", "0"},
            {"z", "2"},
        };

        public static Dictionary<string, string> StandardGalacticAlphabet = new()
        {
            {"a", "ᔑ"},
            {"b", "ʖ"},
            {"c", "ᓵ"},
            {"d", "↸"},
            {"e", "ᒷ"},
            {"f", "⎓"},
            {"g", "⊣"},
            {"h", "⍑"},
            {"i", "╎"},
            {"j", "⋮"},
            {"k", "ꖌ"},
            {"l", "ꖎ"},
            {"m", "ᒲ"},
            {"n", "リ"},
            {"o", "𝙹"},
            {"p", "!¡"},
            {"q", "ᑑ"},
            {"r", "∷"},
            {"s", "ᓭ"},
            {"t", "ℸ ̣"},
            {"u", "⚍"},
            {"v", "⍊"},
            {"w", "∴"},
            {"x", " ̇/"},
            {"y", "||"},
            {"z", "⨅"},
        };

        public static Dictionary<string, string> braille = new()
        {
            {"a", "⠁"},
            {"b", "⠃"},
            {"c", "⠉"},
            {"d", "⠙"},
            {"e", "⠑"},
            {"f", "⠋"},
            {"g", "⠛"},
            {"h", "⠓"},
            {"i", "⠊"},
            {"j", "⠚"},
            {"k", "⠅"},
            {"l", "⠇"},
            {"m", "⠍"},
            {"n", "⠝"},
            {"o", "⠕"},
            {"p", "⠏"},
            {"q", "⠟"},
            {"r", "⠗"},
            {"s", "⠎"},
            {"t", "⠞"},
            {"u", "⠥"},
            {"v", "⠧"},
            {"w", "⠺"},
            {"x", "⠭"},
            {"y", "⠽"},
            {"z", "⠵"},
            {"1", "⠼⠁"},
            {"2", "⠼⠃"},
            {"3", "⠼⠉"},
            {"4", "⠼⠙"},
            {"5", "⠼⠑"},
            {"6", "⠼⠋"},
            {"7", "⠼⠛"},
            {"8", "⠼⠓"},
            {"9", "⠼⠊"},
            {"0", "⠼⠚"},
            {"-", "⠤"},
            {"'", "⠄"},
            {"”", "⠄⠶"},
            {"“", "⠄⠶"},
            {"*", "⠔"},
            {"\"", "⠄⠶"},
            {"?", "⠦"},
            {")", "⠐⠜"},
            {"(", "⠐⠣"},
            {"!", "⠖"},
            {".", "⠲"},
            {":", "⠒"},
            {";", "⠆"},
            {",", "⠂"},
            {"", "⠼" },
        };

        public static Dictionary<string, string> superscript = new()
        {
            { "A", "ᴬ" },
            { "a", "ᵃ" },
            { "B", "ᴮ" },
            { "b", "ᵇ" },
            { "C", "ᶜ" },
            { "c", "ᶜ" },
            { "D", "ᴰ" },
            { "d", "ᵈ" },
            { "E", "ᴱ" },
            { "e", "ᵉ" },
            { "F", "ᶠ" },
            { "f", "ᶠ" },
            { "G", "ᴳ" },
            { "g", "ᵍ" },
            { "H", "ᴴ" },
            { "h", "ʰ" },
            { "I", "ᴵ" },
            { "i", "ᶦ" },
            { "J", "ᴶ" },
            { "j", "ʲ" },
            { "K", "ᴷ" },
            { "k", "ᵏ" },
            { "L", "ᴸ" },
            { "l", "ˡ" },
            { "M", "ᴹ" },
            { "m", "ᵐ" },
            { "N", "ᴺ" },
            { "n", "ⁿ" },
            { "O", "ᴼ" },
            { "o", "ᵒ" },
            { "P", "ᴾ" },
            { "p", "ᵖ" },
            { "Q", "Q" },
            { "q", "ᑫ" },
            { "R", "ᴿ" },
            { "r", "ʳ" },
            { "S", "ˢ" },
            { "s", "ˢ" },
            { "T", "ᵀ" },
            { "t", "ᵗ" },
            { "U", "ᵁ" },
            { "u", "ᵘ" },
            { "V", "ⱽ" },
            { "v", "ᵛ" },
            { "W", "ᵂ" },
            { "w", "ʷ" },
            { "X", "ˣ" },
            { "x", "ˣ" },
            { "Y", "ʸ" },
            { "y", "ʸ" },
            { "Z", "ᶻ" },
            { "z", "ᶻ" },
            { "1", "¹" },
            { "2", "²" },
            { "3", "³" },
            { "4", "⁴" },
            { "5", "⁵" },
            { "6", "⁶" },
            { "7", "⁷" },
            { "8", "⁸" },
            { "9", "⁹" },
            { "0", "⁰" },
            { "-", "⁻" },
            { "=", "⁼" },
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

        public static string Encode(string Input, Dictionary<string, string> keys, string Name, string seperator = "", string splitter = "", bool errors = true)
        {
            string[] InputSplit = Input.Split(splitter);

            if (splitter == "")
                InputSplit = Input.ToArray().ToStringArray();

            string returnValue = "";
            ProgressBar bar = new(Name, InputSplit.Length);

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

                    if (errors)
                        Program.Error($"{Name}: Cannot convert key {InputSplit[i]}");
                }
            }

            if (returnValue.Length == 0)
                return returnValue;

            return returnValue[seperator.Length..];
        }

        public static string Decode(string Input, Dictionary<string, string> keys, string Name, string splitter = "", bool errors = true)
        {
            return Encode(Input, keys.FlipDict(), Name, "", splitter, errors);
        }

        public static string Repeat(string Input, int amount, bool encode)
        {
            if (!encode)
            {
                new ProgressBar("Repeat Backwards", 1, 1).Print();
                return Input.Substring(0, Input.Length / amount);
            }
            ProgressBar bar = new("Repeat", amount);

            string returnValue = "";

            for (int i = 0; i < amount; i++)
            {
                returnValue += Input;
                bar.Increase();
            }

            return returnValue;
        }

        public static string RepeatUntilLength(string Input, uint length)
        {
            ProgressBar bar = new("Repeat until length", (int)Math.Ceiling((float)length / Input.Length));

            if (Input.Length > length)
                return Program.Error($"{Input} is already over {length}", Input);

            string returnValue = "";
            while (true)
            {
                if (returnValue.Length + Input.Length > length)
                    return returnValue;

                bar.Increase();

                returnValue += Input;
            }
        }
    }
}
