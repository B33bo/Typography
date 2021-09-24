using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typography
{
    public static class Typography
    {
        public static string DoTypographyType(TypographyType type, string input, string[] Params)
        {
            bool toEncode = true;

            if (Params.Length > 1)
                toEncode = Params.safeGet(1, "true").isTrue();

            switch (type)
            {
                case TypographyType.None:
                    return input;

                case TypographyType.Normal:
                    return input;

                case TypographyType.Reverse:
                    return BackwardsText.Flip(input);

                case TypographyType.Upsideown:
                    return Upsidedown.Upsideown(input);

                case TypographyType.Randomize:
                    return Randomize.Jumble(input);

                case TypographyType.error:
                    bool fromUser = Params[0].ToLower() == "error";
                    string hardCodedError = $"{Params[0]} is an invalid command";

                    if (fromUser)
                        Program.Error(Params.Length >= 2 ? Params[1] : input);
                    else
                        Program.Error(hardCodedError);

                    return input;

                case TypographyType.append:
                    new ProgressBar("Append", 1, 1).Print();

                    return Params.safeGet(2, "true").isTrue() ? input + Params.safeGet(1) :
                        Append.Decode(input, Params.safeGet(1));

                case TypographyType.periodicTable:
                    return toEncode ? PeriodicTable.Encode(input) : PeriodicTable.Decode(input);

                case TypographyType.bigLetters:
                    return toEncode ? BigLetters.Encode(input) : ConvertToHashtable.Encode(input);

                case TypographyType.copyText:
                    new ProgressBar("Copy", 1, 1).Print();

                    if (input == string.Empty)
                        Program.Error("Cannot copy empty string!!");
                    else
                        Clipboard.SetText(input);

                    return input;

                case TypographyType.invertCondition:
                    return InvertCondition.FlipCondition(input);

                case TypographyType.SentencePyramid:
                    return SentencePyramid.sentencePyramid(input);

                case TypographyType.sevenSegmentDisplay:
                    return sevenSegDisplay.SevenSegDisplay(input).ToString();

                case TypographyType.replaceXwithY:
                    return replaceXwithY.ReplaceXwithY(input, Params.safeGet(1), Params.safeGet(2));

                case TypographyType.longerWord:
                    new ProgressBar("longer", 1, 1).Print();
                    return longerAndShorter.Longer(input, Params.safeGet(1));

                case TypographyType.shorterWord:
                    new ProgressBar("shorter", 1, 1).Print();
                    return longerAndShorter.Shorter(input, Params.safeGet(1));

                case TypographyType.equal:
                    new ProgressBar("equal", 1, 1).Print();
                    return longerAndShorter.EqualTo(input, Params.safeGet(1)).ToString();

                case TypographyType.discordemoji:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.discordEmoji, "Discord Emoji (decode)", " ") :
                        TextToEncode.Decode(input, TextToEncode.discordEmoji, "Discord Emoji (decode)", " ");

                case TypographyType.bubble:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.BubbleText, "Bubble text (encode)") :
                        TextToEncode.Decode(input, TextToEncode.BubbleText, "Bubble text (decode)");

                case TypographyType.blackbubble:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.blackBubbleText, "Black bubble (encode)") :
                        TextToEncode.Decode(input, TextToEncode.blackBubbleText, "Black bubble (decode)");

                case TypographyType.userinput:
                    return methodCode.CheckForVars(Console.ReadLine());

                case TypographyType.inputIntoVar:
                    Program.oldInput = methodCode.CheckForVars(Console.ReadLine());
                    return input;

                case TypographyType.repeat:
                    if (!int.TryParse(Params.safeGet(1), out int res))
                        return Program.Error($"'{Params.safeGet(1)}' is not a string.", input);

                    bool isTrue = Params.safeGet(2, "true").isTrue();

                    Console.WriteLine(Params.safeGet(2, "true"));
                    return TextToEncode.Repeat(input, res, isTrue);

                case TypographyType.oldSchool:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.oldSchool, "Old school (encode)") :
                        TextToEncode.Decode(input, TextToEncode.oldSchool, "Old school (decode)");

                case TypographyType.write:
                    new ProgressBar("Write to file", 1, 1).Print();

                    try
                    {
                        if (!File.Exists(Params.safeGet(1)))
                            return Program.Error($"{Params.safeGet(1)} is not a file. Cannot write to", input);

                        File.WriteAllText(Params.safeGet(1), input);
                    }
                    catch (IOException exc)
                    {
                        Program.Error("An error occured when writing to disc: " + exc.Message);
                    }
                    return input;

                case TypographyType.read:
                    new ProgressBar("Read from file", 1, 1).Print();

                    try
                    {
                        if (!File.Exists(input))
                            return Program.Error($"{input} is not a file. Cannot read from", input);

                        return File.ReadAllText(input);
                    }
                    catch (IOException exc)
                    {
                        return Program.Error("An error occured when reading from disc: " + exc.Message, input);
                    }

                case TypographyType.zalgo:
                    if (Params.Length == 1)
                        return Zalgo.Encode(input);

                    if (Params.Length == 2)
                    {
                        return toEncode ? Zalgo.Encode(input) :
                            Zalgo.Decode(input);
                    }

                    uint zalgup;
                    uint zalgmid;
                    uint zalgdown;

                    if (!uint.TryParse(Params.safeGet(1), out zalgup) ||
                        !uint.TryParse(Params.safeGet(2), out zalgmid) ||
                        !uint.TryParse(Params.safeGet(3), out zalgdown))
                    {
                        return Program.Error($"Either {Params.safeGet(1)}, {Params.safeGet(2)}, or {Params.safeGet(3)} was not a positive number", input);
                    }

                    return Zalgo.Encode(input, zalgup, zalgmid, zalgdown);

                case TypographyType.expand:
                    if (!uint.TryParse(Params.safeGet(1), out uint expandness))
                        return Program.Error($"{Params.safeGet(1)} is not a positive number", input);

                    return Params.safeGet(2, "true").isTrue() ? expand.Encode(input, expandness) :
                        expand.Decode(input, expandness);

                case TypographyType.doubleStruck:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.doubleStruck, "Double struck (encode)") :
                        TextToEncode.Decode(input, TextToEncode.doubleStruck, "Double struck (decode)");

                case TypographyType.discordSpoiler:
                    return toEncode ? discordSpoiler.Encode(input) : discordSpoiler.Decode(input);

                case TypographyType.morsecode:
                    if (Params.Length >= 2)
                        if (Params[1] == "sing")
                            return MorseCodeSing.SingMorseCode(input, Params.safeGet(2, "true").isTrue());

                    return toEncode ? TextToEncode.Encode(input, TextToEncode.morseCode, "Morse code (encode)", " / ") :
                        TextToEncode.Decode(input, TextToEncode.morseCode, "Morse code (decode)", "/");

                case TypographyType.nato:
                    return toEncode ? Phonetics.Encode(input, Phonetics.NATO, "NATO (encode)") :
                        Phonetics.Decode(input, "NATO (decode)");

                case TypographyType.binary:
                    return toEncode ? BinaryText.Encode(input) : BinaryText.Decode(input);

                case TypographyType.NumberBase:
                    int BaseForEncoding = 10;
                    int padding = 2;

                    if (Params.Length > 3)
                    {
                        if (!int.TryParse(Params.safeGet(2), out BaseForEncoding) ||
                            !int.TryParse(Params.safeGet(3), out padding))
                        {
                            return Program.Error($"Either {Params.safeGet(2)} or {Params.safeGet(3)} was not an int", input);
                        }
                    }
                    else if (Params.Length == 3)
                    {
                        if (!int.TryParse(Params.safeGet(1), out BaseForEncoding) ||
                            !int.TryParse(Params.safeGet(2), out padding))
                        {
                            return Program.Error($"Either {Params.safeGet(1)} or {Params.safeGet(2)} was not an int", input);
                        }

                        return Number.Encode(input, BaseForEncoding, padding);
                    }

                    return toEncode ? Number.Encode(input, BaseForEncoding, padding) :
                        Number.Decode(input, BaseForEncoding, padding);

                case TypographyType.hash:
                    return Hashing.Hash(input, Params.safeGet(1));

                case TypographyType.googleTranslate:
                    return GTranslator.Translate(input, Params.safeGet(1), Params.safeGet(2));

                case TypographyType.nonsensify:
                    return GTranslator.Nonsense(input);

                case TypographyType.caesar:
                    if (!int.TryParse(Params.safeGet(1), out int CaesarAmount))
                        return Program.Error($"{Params.safeGet(1)} was not an int", input);

                    return Caesar.Encode(input, CaesarAmount);

                case TypographyType.capsRandomizer:
                    return capsRandomizer.Randomize(input);

                case TypographyType.owoify:
                    return owoify.Encode(input);

                case TypographyType.set:
                    string value = Params.Length <= 2 ? input : Params[2];

                    if (methodCode.variables.ContainsKey(Params.safeGet(1)))
                        methodCode.variables[Params.safeGet(1).ToLower()] = value;
                    else
                        methodCode.variables.Add(Params.safeGet(1).ToLower(), value);
                    return input;

                case TypographyType.change:
                    return Params.safeGet(1);

                case TypographyType.substring:
                    if (!int.TryParse(Params.safeGet(1), out int start))
                    {
                        return Program.Error($"Substring: {Params.safeGet(1)} was not an int", input);
                    }

                    int substringLength = -1;
                    if (Params.Length > 2)
                    {
                        if (!int.TryParse(Params.safeGet(2), out substringLength))
                        {
                            return Program.Error($"Substring: {Params.safeGet(2)} was not an int", input);
                        }
                    }

                    if (start + substringLength > input.Length)
                    {
                        return Program.Error(
                            $"Start bound + length ({start + substringLength}) is higher than the length of the string ({input.Length})"
                            , input);
                    }

                    if (substringLength < 0)
                        return input[start..];

                    return input.Substring(start, substringLength);

                case TypographyType.appendBehind:
                    if (Params.safeGet(2, "true").isTrue())
                    {
                        return Params.safeGet(1) + input;
                    }
                    else
                    {
                        string param1 = Params.safeGet(1);
                        return input.Substring(param1.Length, input.Length - param1.Length);
                    }

                case TypographyType.length:
                    return input.Length.ToString();

                case TypographyType.uppercase:
                    return input.ToUpper();

                case TypographyType.lowercase:
                    return input.ToLower();

                case TypographyType.smallcaps:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.smallcaps, "small caps (encode)") :
                        TextToEncode.Decode(input, TextToEncode.smallcaps, "small caps (decode)");

                case TypographyType.bold:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.bold, "bold (encode)") :
                        TextToEncode.Decode(input, TextToEncode.bold, "bold (decode)");

                case TypographyType.italics:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.italics, "italics (encode)") :
                        TextToEncode.Decode(input, TextToEncode.italics, "italics (decode)");

                case TypographyType.bolditalics:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.boldItalics, "bold-italics (encode)") :
                        TextToEncode.Decode(input, TextToEncode.boldItalics, "bold-italics (decode)");

                case TypographyType.clear:
                    Console.Clear();
                    return input;

                case TypographyType.htmlText:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.textToHtml, "HTML text (encode)", "", "", false)
                        : TextToEncode.Decode(input, TextToEncode.textToHtml, "HTML text (decode)", "", false);

                case TypographyType.call:
                    if (!methodCode.methods.ContainsKey(Params.safeGet(1)))
                        return Program.Error($"Method {Params.safeGet(1)} does not exist!", input);

                    return methodCode.methods[Params.safeGet(1)].compute(input);

                case TypographyType.delay:
                    if (!int.TryParse(Params.safeGet(1), out int delay))
                        return Program.Error($"{Params.safeGet(1)} is not a valid delay.", input);

                    System.Threading.Thread.Sleep(Math.Abs(delay));
                    return input;

                case TypographyType.If:
                    if (!methodCode.methods.ContainsKey(Params.safeGet(1)))
                        return Program.Error($"Method {Params.safeGet(1)} does not exist!", input);

                    if (input.ToLower() == "true")
                        return methodCode.methods[Params.safeGet(1)].compute(input);

                    return input;
                case TypographyType.IfElse:
                    if (!methodCode.methods.ContainsKey(Params.safeGet(1)))
                        return Program.Error($"Method {Params.safeGet(1)} does not exist!", input);

                    if (!methodCode.methods.ContainsKey(Params.safeGet(2)))
                        return Program.Error($"Method {Params.safeGet(2)} does not exist!", input);

                    if (input.ToLower() == "true")
                        return methodCode.methods[Params.safeGet(1)].compute(input);

                    return methodCode.methods[Params.safeGet(2)].compute(input);

                case TypographyType.leetspeak:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.leetSpeak, "1337 speak (encode)", "", "", false) :
                        TextToEncode.Decode(input, TextToEncode.leetSpeak, "1337 speak (decode)", "", false);

                case TypographyType.StandardGalacticAlphabet:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.StandardGalacticAlphabet, "Standard galactic (encode)") :
                        TextToEncode.Decode(input, TextToEncode.StandardGalacticAlphabet, "Standard galactic (decode)");

                case TypographyType.british:
                    return toEncode ? British.Encode(input) : British.Decode(input);

                case TypographyType.numericAlphabet:
                    return toEncode ? NumericAlphabet.Encode(input) : NumericAlphabet.Decode(input);

                case TypographyType.braille:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.braille, "Braille (Encode)") :
                        Braille.Decode(input);

                case TypographyType.math:
                    if (!double.TryParse(input, out double mathsResult))
                        return Program.Error($"maths : {input} (input) is not a number", input);

                    if (Params.Length <= 2)
                        return MathsSolve.Value(mathsResult, Params.safeGet(1)).ToString();

                    if (!double.TryParse("0" + Params.safeGet(2), out double mathsResultNum2))
                        return Program.Error($"maths : {Params.safeGet(2)} (param) is not a number", input);

                    return MathsSolve.Value(mathsResult, Params.safeGet(1), mathsResultNum2).ToString();

                case TypographyType.badspelling:
                    return BadSpelling.Encode(input);

                case TypographyType.print:
                    ConsoleColor consoleColorText = ConsoleColor.White;
                    if (Params.Length > 1)
                    {
                        if (!Enum.TryParse(Params[1], out consoleColorText))
                            Program.Error($"{Params[1]} is not a console color. ");
                    }

                    Console.ForegroundColor = consoleColorText;

                    Console.Write(Params.Length >= 3 ? Params[2] : input);
                    Console.ResetColor();

                    return input;

                case TypographyType.background:
                    if (!Enum.TryParse(Params.safeGet(1), out ConsoleColor consoleColorBack))
                        Program.Error($"{Params.safeGet(1)} is not a console color. ");

                    Console.BackgroundColor = consoleColorBack;

                    return input;

                case TypographyType.showtutorial:
                    Console.WriteLine(Program.AllTypes("\n"));
                    return input;
                case TypographyType.debug:

                    if (Params.Length <= 1)
                    {
                        Program.DebugMode = !Program.DebugMode;
                        return input;
                    }
                    Program.DebugMode = Params[1].isTrue();
                    return input;
                case TypographyType.wordShift:
                    if (!int.TryParse(Params.safeGet(1), out int wordShiftAmount))
                        return Program.Error($"Wordshift: {wordShiftAmount} is not an int", input);

                    return WordShift.ShiftWords(input, wordShiftAmount);

                case TypographyType.discordtime:
                    return ToDiscordTimestamp.Encode(input, Params.safeGet(1, "f"));
            }

            Program.Error($"{type} is not yet implemented");
            return input;
        }

        public static string ToReadableString(this TypographyType input)
        {
            switch (input)
            {
                case TypographyType.None:
                    return "None                    none";
                case TypographyType.Normal:
                    return "Normal                  normal";
                case TypographyType.Reverse:
                    return "Reverse                 reverse";
                case TypographyType.Upsideown:
                    return "Upsideown               upsidedown";
                case TypographyType.Randomize:
                    return "Randomize               randomize";
                case TypographyType.error:
                    return "error                   error";
                case TypographyType.append:
                    return "append string           append~X~encode/decode";
                case TypographyType.periodicTable:
                    return "Periodic Table          periodic~encode/decode";
                case TypographyType.bigLetters:
                    return "Big Letters             big";
                case TypographyType.copyText:
                    return "Copy to Clipboard       copy";
                case TypographyType.invertCondition:
                    return "Invert as condition     invertbool";
                case TypographyType.SentencePyramid:
                    return "Sentence Pyramid        pyramid~encode/decode";
                case TypographyType.sevenSegmentDisplay:
                    return "7-segment display       7segdisplay";
                case TypographyType.replaceXwithY:
                    return "replace X with Y        replace~X~Y";
                case TypographyType.longerWord:
                    return "X longer than Y         longer~Y";
                case TypographyType.shorterWord:
                    return "X shorter than Y        shorter~Y";
                case TypographyType.equal:
                    return "X equal length to Y     equal";
                case TypographyType.discordemoji:
                    return "discord emoji speak     discordemoji~encode/decode";
                case TypographyType.bubble:
                    return "bubble text             bubble~encode/decode";
                case TypographyType.blackbubble:
                    return "black bubble text       blackbubble~encode/decode";
                case TypographyType.userinput:
                    return "user input              input";
                case TypographyType.inputIntoVar:
                    return "input into var %input%  inputIntoVar";
                case TypographyType.repeat:
                    return "repeat                  repeat~X~encode/decode";
                case TypographyType.oldSchool:
                    return "Old School              oldschool~encode/decode";
                case TypographyType.write:
                    return "Write to file           write~path";
                case TypographyType.read:
                    return "Read from file          read";
                case TypographyType.zalgo:
                    return "Zalgo                   zalgo~encode/decode~zalgoUp~zalgoMid~zalgoDown";
                case TypographyType.expand:
                    return "eexxppaanndd (expand)   expand~amount~encode/decode";
                case TypographyType.doubleStruck:
                    return "double struck           doublestruck~encode/decode";
                case TypographyType.discordSpoiler:
                    return "discord spoiler         spoiler~encode/decode";
                case TypographyType.morsecode:
                    return "morse code              morsecode~encode/decode/sing";
                case TypographyType.nato:
                    return "nato (alfa, bravo...)   nato~encode/decode";
                case TypographyType.binary:
                    return "binary                  binary~encode/decode";
                case TypographyType.NumberBase:
                    return "NumberBase              NumberBase~encode/decode~base~padding";
                case TypographyType.hash:
                    return "hash                    hash~sha1/sha256/sha384/sha512/md5";
                case TypographyType.googleTranslate:
                    return "google translate        translate~fromLanguage~toLanguage";
                case TypographyType.nonsensify:
                    return "nonsensify              nonsensify";
                case TypographyType.caesar:
                    return "caesar cipher           caesar~chars";
                case TypographyType.capsRandomizer:
                    return "cAps RaANdoMIzer        caps";
                case TypographyType.owoify:
                    return "owoify                  owoify";
                case TypographyType.set:
                    return "set variable            set~name";
                case TypographyType.change:
                    return "change current string   change~value";
                case TypographyType.appendBehind:
                    return "append behind           appendbehind~value~encode/decode";
                case TypographyType.length:
                    return "length of string        length";
                case TypographyType.substring:
                    return "substring               substring~start~length";
                case TypographyType.uppercase:
                    return "uppercase               uppercase";
                case TypographyType.lowercase:
                    return "lowercase               lowercase";
                case TypographyType.smallcaps:
                    return "smallcaps               smallcaps~encode/decode";
                case TypographyType.bold:
                    return "Bold                    bold~encode/decode";
                case TypographyType.italics:
                    return "italics                 italics~encode/decode";
                case TypographyType.bolditalics:
                    return "Bolditalics             BoldItalics~encode/decode";
                case TypographyType.clear:
                    return "Clear console           clear";
                case TypographyType.htmlText:
                    return "Html text encode        htmltxt~encode/decode";
                case TypographyType.call:
                    return "Call method             call~MethodName";
                case TypographyType.delay:
                    return "Pause for time          delay~milloseconds";
                case TypographyType.If:
                    return "if bool call value      if~methodname";
                case TypographyType.IfElse:
                    return "if bool else            if~callIfTrue~callIfFalse";
                case TypographyType.leetspeak:
                    return "1337 5p34k              1337~encode/decode";
                case TypographyType.StandardGalacticAlphabet:
                    return "Standard galactic       galactic~encode/decode";
                case TypographyType.british:
                    return "Bri'ish                 british~encode/decode";
                case TypographyType.numericAlphabet:
                    return "Numeric (A=1, B=2)      numeric~encode/decode";
                case TypographyType.braille:
                    return "Braille                 braille~encode/decode";
                case TypographyType.math:
                    return "Maths                   math~operator~number";
                case TypographyType.badspelling:
                    return "Bad Speling             badspelling";
                case TypographyType.print:
                    return "Print                   print~colour~message";
                case TypographyType.background:
                    return "Set Background          background~colour";
                case TypographyType.showtutorial:
                    return "Show tutorial           showtutorial";
                case TypographyType.debug:
                    return "Debug mode              debug~on/off";
                case TypographyType.wordShift:
                    return "Word shift              wordshift~amount";
                case TypographyType.discordtime:
                    return "Discord Time            discordtime~encoding";
                default:
                    return input.ToString();
            }
        }

        public static TypographyType ParseAsType(this string input)
        {
            switch (input.ToLower().Trim())
            {
                default:
                    return TypographyType.error;
                case "none":
                    return TypographyType.None;
                case "normal":
                    return TypographyType.Normal;
                case "reverse":
                    return TypographyType.Reverse;
                case "upsidedown":
                    return TypographyType.Upsideown;
                case "randomize":
                    return TypographyType.Randomize;
                case "error":
                    return TypographyType.error;
                case "append":
                    return TypographyType.append;
                case "periodic":
                    return TypographyType.periodicTable;
                case "big":
                    return TypographyType.bigLetters;
                case "copy":
                    return TypographyType.copyText;
                case "invertbool":
                    return TypographyType.invertCondition;
                case "pyramid":
                    return TypographyType.SentencePyramid;
                case "7segdisplay":
                    return TypographyType.sevenSegmentDisplay;
                case "replace":
                    return TypographyType.replaceXwithY;
                case "longer":
                    return TypographyType.longerWord;
                case "shorter":
                    return TypographyType.shorterWord;
                case "equal":
                    return TypographyType.equal;
                case "discordemoji":
                    return TypographyType.discordemoji;
                case "bubble":
                    return TypographyType.bubble;
                case "blackbubble":
                    return TypographyType.blackbubble;
                case "input":
                    return TypographyType.userinput;
                case "inputintovar":
                    return TypographyType.inputIntoVar;
                case "repeat":
                    return TypographyType.repeat;
                case "oldschool":
                    return TypographyType.oldSchool;
                case "write":
                    return TypographyType.write;
                case "read":
                    return TypographyType.read;
                case "zalgo":
                    return TypographyType.zalgo;
                case "expand":
                    return TypographyType.expand;
                case "doublestruck":
                    return TypographyType.doubleStruck;
                case "spoiler":
                    return TypographyType.discordSpoiler;
                case "morsecode":
                    return TypographyType.morsecode;
                case "nato":
                    return TypographyType.nato;
                case "binary":
                    return TypographyType.binary;
                case "numberbase":
                    return TypographyType.NumberBase;
                case "hash":
                    return TypographyType.hash;
                case "translate":
                    return TypographyType.googleTranslate;
                case "nonsensify":
                    return TypographyType.nonsensify;
                case "caesar":
                    return TypographyType.caesar;
                case "caps":
                    return TypographyType.capsRandomizer;
                case "owoify":
                    return TypographyType.owoify;
                case "set":
                    return TypographyType.set;
                case "change":
                    return TypographyType.change;
                case "substring":
                    return TypographyType.substring;
                case "appendbehind":
                    return TypographyType.appendBehind;
                case "length":
                    return TypographyType.length;
                case "lowercase":
                    return TypographyType.lowercase;
                case "uppercase":
                    return TypographyType.uppercase;
                case "smallcaps":
                    return TypographyType.smallcaps;
                case "bold":
                    return TypographyType.bold;
                case "italics":
                    return TypographyType.italics;
                case "bolditalics":
                    return TypographyType.bolditalics;
                case "clear":
                    return TypographyType.clear;
                case "htmltxt":
                    return TypographyType.htmlText;
                case "call":
                    return TypographyType.call;
                case "delay":
                    return TypographyType.delay;
                case "if":
                    return TypographyType.If;
                case "ifelse":
                    return TypographyType.IfElse;
                case "1337":
                case "leet":
                    return TypographyType.leetspeak;
                case "galactic":
                    return TypographyType.StandardGalacticAlphabet;
                case "british":
                    return TypographyType.british;
                case "numeric":
                    return TypographyType.numericAlphabet;
                case "braille":
                    return TypographyType.braille;
                case "math":
                case "maths":
                    return TypographyType.math;
                case "badspelling":
                    return TypographyType.badspelling;
                case "print":
                    return TypographyType.print;
                case "background":
                    return TypographyType.background;
                case "showtutorial":
                    return TypographyType.showtutorial;
                case "debug":
                    return TypographyType.debug;
                case "wordshift":
                    return TypographyType.wordShift;
                case "discordtime":
                    return TypographyType.discordtime;
                case "":
                case " ":
                    return TypographyType.None;
            }
        }
    }

    public enum TypographyType
    {
        None,
        Normal,
        Reverse,
        Upsideown,
        Randomize,
        error,
        append,
        periodicTable,
        bigLetters,
        copyText,
        invertCondition,
        SentencePyramid,
        sevenSegmentDisplay,
        replaceXwithY,
        longerWord,
        shorterWord,
        equal,
        discordemoji,
        bubble,
        blackbubble,
        userinput,
        inputIntoVar,
        repeat,
        oldSchool,
        write,
        read,
        zalgo,
        expand,
        doubleStruck,
        discordSpoiler,
        morsecode,
        nato,
        binary,
        NumberBase,
        hash,
        googleTranslate,
        nonsensify,
        caesar,
        capsRandomizer,
        owoify,
        set,
        change,
        substring,
        appendBehind,
        length,
        uppercase,
        lowercase,
        smallcaps,
        bold,
        italics,
        bolditalics,
        clear,
        htmlText,
        call,
        delay,
        If,
        IfElse,
        leetspeak,
        StandardGalacticAlphabet,
        british,
        numericAlphabet,
        braille,
        math,
        badspelling,
        print,
        background,
        showtutorial,
        debug,
        wordShift,
        discordtime,
    }
}
