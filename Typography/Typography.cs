using System;
using System.IO;
using System.Text.RegularExpressions;
using Typography.Meta;

namespace Typography
{
    public static class Typography
    {
        public static string DoTypographyType(TypographyType type, string input, string[] Params)
        {
            bool toEncode = true;

            if (Params.Length > 1)
                toEncode = Params.SafeGet(1, "true").IsTrue();

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
                    return toEncode ? Randomize.Jumble(input) :
                        AnagramSolver.DeAnagram(input);

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

                    return Params.SafeGet(2, "true").IsTrue() ? input + Params.SafeGet(1) :
                        Append.Decode(input, Params.SafeGet(1));

                case TypographyType.periodicTable:
                    return toEncode ? PeriodicTable.Encode(input) : PeriodicTable.Decode(input);

                case TypographyType.bigLetters:
                    return toEncode ? BigLetters.Encode(input) : ConvertToHashtable.Encode(input);

                case TypographyType.copyText:
                    new ProgressBar("Copy", 1, 1).Print();

                    if (input == string.Empty)
                        Program.Error("Cannot copy empty string!!");
                    else
                        System.Windows.Forms.Clipboard.SetText(input);

                    return input;

                case TypographyType.invertCondition:
                    return InvertCondition.FlipCondition(input);

                case TypographyType.SentencePyramid:
                    return SentencePyramid.Encode(input);

                case TypographyType.sevenSegmentDisplay:
                    return SevenSegDisplay.Encode(input).ToString();

                case TypographyType.replaceXwithY:
                    return ReplaceXwithY.Encode(input, Params.SafeGet(1), Params.SafeGet(2));

                case TypographyType.longerWord:
                    string Along = Params.SafeGet(1);
                    string Blong = Params.SafeGet(2, input);

                    return Along.Length < Blong.Length ? Along : Blong;

                case TypographyType.shorterWord:
                    string Ashort = Params.SafeGet(1);
                    string Bshort = Params.SafeGet(2, input);

                    return Ashort.Length > Bshort.Length ? Ashort : Bshort;

                case TypographyType.equal:
                    return (Params.SafeGet(1) == Params.SafeGet(2, input)).ToString();

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
                    return MethodCode.CheckForVars(Console.ReadLine());

                case TypographyType.inputIntoVar:
                    Program.oldInput = MethodCode.CheckForVars(Console.ReadLine());
                    return input;

                case TypographyType.repeat:
                    if (!int.TryParse(Params.SafeGet(1), out int res))
                        return Program.Error($"'{Params.SafeGet(1)}' is not a number.", input);

                    bool isTrue = Params.SafeGet(2, "true").IsTrue();

                    Console.WriteLine(Params.SafeGet(2, "true"));
                    return TextToEncode.Repeat(input, res, isTrue);

                case TypographyType.oldSchool:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.oldSchool, "Old school (encode)") :
                        TextToEncode.Decode(input, TextToEncode.oldSchool, "Old school (decode)");

                case TypographyType.write:
                    new ProgressBar("Write to file", 1, 1).Print();

                    try
                    {
                        if (!File.Exists(Params.SafeGet(1)))
                            return Program.Error($"{Params.SafeGet(1)} is not a file. Cannot write to", input);

                        File.WriteAllText(Params.SafeGet(1), input);
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

                    if (!uint.TryParse(Params.SafeGet(1), out zalgup) ||
                        !uint.TryParse(Params.SafeGet(2), out zalgmid) ||
                        !uint.TryParse(Params.SafeGet(3), out zalgdown))
                    {
                        return Program.Error($"Either {Params.SafeGet(1)}, {Params.SafeGet(2)}, or {Params.SafeGet(3)} was not a positive number", input);
                    }

                    return Zalgo.Encode(input, zalgup, zalgmid, zalgdown);

                case TypographyType.expand:
                    if (!uint.TryParse(Params.SafeGet(1), out uint expandness))
                        return Program.Error($"{Params.SafeGet(1)} is not a positive number", input);

                    return Params.SafeGet(2, "true").IsTrue() ? Expand.Encode(input, expandness) :
                        Expand.Decode(input, expandness);

                case TypographyType.doubleStruck:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.doubleStruck, "Double struck (encode)") :
                        TextToEncode.Decode(input, TextToEncode.doubleStruck, "Double struck (decode)");

                case TypographyType.discordSpoiler:
                    return toEncode ? DiscordSpoiler.Encode(input) : DiscordSpoiler.Decode(input);

                case TypographyType.morsecode:
                    if (Params.Length >= 2)
                        if (Params[1] == "sing")
                            return MorseCodeSing.SingMorseCode(input, Params.SafeGet(2, "true").IsTrue());

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
                        if (!int.TryParse(Params.SafeGet(2), out BaseForEncoding) ||
                            !int.TryParse(Params.SafeGet(3), out padding))
                            return Program.Error($"Either {Params.SafeGet(2)} or {Params.SafeGet(3)} was not an int", input);
                    }

                    else if (Params.Length == 3)
                    {
                        if (!int.TryParse(Params.SafeGet(1), out BaseForEncoding) ||
                            !int.TryParse(Params.SafeGet(2), out padding))
                        {
                            return Program.Error($"Either {Params.SafeGet(1)} or {Params.SafeGet(2)} was not an int", input);
                        }

                        return Number.Encode(input, BaseForEncoding, padding);
                    }

                    if (Params.SafeGet(4, "false").IsTrue())
                    {
                        return toEncode ? Number.EncodeNum(input, BaseForEncoding, padding) :
                            Number.DecodeNum(input, BaseForEncoding).ToString();
                    }

                    return toEncode ? Number.Encode(input, BaseForEncoding, padding) :
                        Number.Decode(input, BaseForEncoding, padding);

                case TypographyType.hash:
                    return Hashing.Hash(input, Params.SafeGet(1));

                case TypographyType.googleTranslate:
                    return GTranslator.Translate(input, Params.SafeGet(1), Params.SafeGet(2));

                case TypographyType.nonsensify:
                    return GTranslator.Nonsense(input);

                case TypographyType.caesar:
                    if (!int.TryParse(Params.SafeGet(1), out int CaesarAmount))
                        return Program.Error($"{Params.SafeGet(1)} was not an int", input);

                    return Caesar.Encode(input, CaesarAmount);

                case TypographyType.capsRandomizer:
                    return CapsRandomizer.Randomize(input);

                case TypographyType.owoify:
                    return Owoify.Encode(input);

                case TypographyType.set:
                    string value = Params.Length <= 2 ? input : Params[2];

                    if (MethodCode.variables.ContainsKey(Params.SafeGet(1)))
                        MethodCode.variables[Params.SafeGet(1).ToLower()] = value;
                    else
                        MethodCode.variables.Add(Params.SafeGet(1).ToLower(), value);

                    return input;

                case TypographyType.change:
                    return Params.SafeGet(1);

                case TypographyType.substring:
                    if (!int.TryParse(Params.SafeGet(1), out int start))
                    {
                        return Program.Error($"Substring: {Params.SafeGet(1)} was not an int", input);
                    }

                    int substringLength = -1;
                    if (Params.Length > 2)
                    {
                        if (!int.TryParse(Params.SafeGet(2), out substringLength))
                        {
                            return Program.Error($"Substring: {Params.SafeGet(2)} was not an int", input);
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
                    if (Params.SafeGet(2, "true").IsTrue())
                    {
                        return Params.SafeGet(1) + input;
                    }
                    else
                    {
                        string param1 = Params.SafeGet(1);

                        if (param1.Length > input.Length)
                            return Program.Error($"{param1.Length} is longer than {input} (original)", input);
                        return input[param1.Length..];
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
                    if (!MethodCode.methods.ContainsKey(Params.SafeGet(1)))
                        return Program.Error($"Method {Params.SafeGet(1)} does not exist!", input);

                    return MethodCode.methods[Params.SafeGet(1)].Compute(input);

                case TypographyType.delay:
                    if (!int.TryParse(Params.SafeGet(1), out int delay))
                        return Program.Error($"{Params.SafeGet(1)} is not a valid delay.", input);

                    System.Threading.Thread.Sleep(Math.Abs(delay));
                    return input;

                case TypographyType.If:
                    if (!MethodCode.methods.ContainsKey(Params.SafeGet(1)))
                        return Program.Error($"Method {Params.SafeGet(1)} does not exist!", input);

                    if (Params.Length > 2)
                        if (!MethodCode.methods.ContainsKey(Params.SafeGet(2)))
                            return Program.Error($"Method {Params.SafeGet(2)} does not exist!", input);

                    if (input.IsTrue())
                        return MethodCode.methods[Params.SafeGet(1)].Compute(input);
                    else if (Params.Length > 2)
                        return MethodCode.methods[Params.SafeGet(2)].Compute(input);

                    return input;

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

                    double mathsA;
                    double mathsB;
                    string oper;
                    if (Params.Length >= 4)
                    {
                        oper = Params.SafeGet(2);

                        if (!double.TryParse(Params.SafeGet(1), out mathsA))
                            return Program.Error($"maths : {Params.SafeGet(1)} is not a number", input);

                        if (!double.TryParse(Params.SafeGet(3, "0"), out mathsB))
                            return Program.Error($"maths : {Params.SafeGet(3)} is not a number", input);
                    }
                    else
                    {
                        oper = Params.SafeGet(1);

                        if (!double.TryParse(input, out mathsA))
                            return Program.Error($"maths : {input} (input) is not a number", input);

                        if (!double.TryParse(Params.SafeGet(2, "0"), out mathsB))
                            return Program.Error($"maths : {Params.SafeGet(2)} is not a number", input);
                    }

                    if (Params.Length <= 2)
                        return MathsSolve.Value(mathsA, oper).ToString();

                    return MathsSolve.Value(mathsA, oper, mathsB).ToString();

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
                    if (!Enum.TryParse(Params.SafeGet(1), out ConsoleColor consoleColorBack))
                        Program.Error($"{Params.SafeGet(1)} is not a console color. ");

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
                    Program.DebugMode = Params[1].IsTrue();
                    return input;
                case TypographyType.wordShift:
                    if (!int.TryParse(Params.SafeGet(1), out int wordShiftAmount))
                        return Program.Error($"Wordshift: {wordShiftAmount} is not an int", input);

                    return WordShift.ShiftWords(input, wordShiftAmount);

                case TypographyType.discordtime:
                    return ToDiscordTimestamp.Encode(input, Params.SafeGet(1, "f"));

                case TypographyType.sprinkle:

                    if (!uint.TryParse(Params.SafeGet(2), out uint sprinkleFreq))
                        return Program.Error($"{Params.SafeGet(2)} is not a positive number", input);

                    return Sprinkle.Encode(input, Params.SafeGet(1), sprinkleFreq);

                case TypographyType.superscript:
                    return toEncode ? TextToEncode.Encode(input, TextToEncode.superscript, "Superscript (encode)") :
                        TextToEncode.Decode(input, TextToEncode.superscript, "Superscript (decode)");

                case TypographyType.parseUnicodeChars:
                    try
                    {
                        return Regex.Unescape(input);
                    }
                    catch (RegexParseException)
                    {
                        return Program.Error($"Cannot parse {input} into unicode", input);
                    }

                case TypographyType.parseVars:
                    return MethodCode.CheckForVars(input, true);

                case TypographyType.increase:
                    IncreaseVar.IncreaseMyVar(Params, input);
                    return input;

                case TypographyType.callmethodfor:
                    string varname = Params.SafeGet(2);

                    if (!MethodCode.variables.ContainsKey(varname))
                        return Program.Error($"{varname} is not a variable", input);

                    if (!MethodCode.methods.ContainsKey(Params.SafeGet(1)))
                        return Program.Error($"{Params.SafeGet(1)} is not a variable", input);

                    MethodCode.variables[varname] = MethodCode.methods[Params.SafeGet(1)].Compute(MethodCode.variables[varname]);
                    return input;

                case TypographyType.repeatuntilover:

                    if (!uint.TryParse(Params.SafeGet(1), out uint repeatLength))
                        return Program.Error($"'{Params.SafeGet(1)}' is not a positive integer.", input);

                    return TextToEncode.RepeatUntilLength(input, repeatLength);

                case TypographyType.unicrush:
                    return toEncode ? Crush.Encode(input, Params.SafeGet(2, "true").IsTrue()) :
                        Crush.Decode(input);
            }

            Program.Error($"{type} is not yet implemented");
            return input;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0066:Convert switch statement to expression", Justification = "It's annoying")]
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
                    return "Anagram                 anagram";
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
                    return "X equal length to Y     equal~Y";
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
                    return "Convert to base         NumBase~encode/decode~base~padding~intmode";
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
                case TypographyType.sprinkle:
                    return "Sprinkle letters        sprinkle~item~frequency";
                case TypographyType.superscript:
                    return "Superscript             superscript~encode/decode";
                case TypographyType.parseUnicodeChars:
                    return "Parse unicode chars     unicodechars";
                case TypographyType.parseVars:
                    return "Parse all variables     parsvars";
                case TypographyType.increase:
                    return "Increase Variable       increase~name~by";
                case TypographyType.callmethodfor:
                    return "Call method for var     callmethodfor~method~varname";
                case TypographyType.repeatuntilover:
                    return "Repeat until over       repeatuntilover~length";
                case TypographyType.unicrush:
                    return "Crush chars             crush~encode/decode~allowIffy";
                default:
                    return input.ToString();
            }
        }

        public static TypographyType ParseAsType(this string input)
        {
            return input.ToLower().Trim() switch
            {
                "none" => TypographyType.None,
                "normal" => TypographyType.Normal,
                "reverse" => TypographyType.Reverse,
                "upsidedown" => TypographyType.Upsideown,
                "randomize" or "anagram" => TypographyType.Randomize,
                "error" => TypographyType.error,
                "append" => TypographyType.append,
                "periodic" => TypographyType.periodicTable,
                "big" => TypographyType.bigLetters,
                "copy" => TypographyType.copyText,
                "invertbool" => TypographyType.invertCondition,
                "pyramid" => TypographyType.SentencePyramid,
                "7segdisplay" => TypographyType.sevenSegmentDisplay,
                "replace" => TypographyType.replaceXwithY,
                "longer" => TypographyType.longerWord,
                "shorter" => TypographyType.shorterWord,
                "equal" => TypographyType.equal,
                "discordemoji" => TypographyType.discordemoji,
                "bubble" => TypographyType.bubble,
                "blackbubble" => TypographyType.blackbubble,
                "input" => TypographyType.userinput,
                "inputintovar" => TypographyType.inputIntoVar,
                "repeat" => TypographyType.repeat,
                "oldschool" => TypographyType.oldSchool,
                "write" => TypographyType.write,
                "read" => TypographyType.read,
                "zalgo" => TypographyType.zalgo,
                "expand" => TypographyType.expand,
                "doublestruck" => TypographyType.doubleStruck,
                "spoiler" => TypographyType.discordSpoiler,
                "morsecode" => TypographyType.morsecode,
                "nato" => TypographyType.nato,
                "binary" => TypographyType.binary,
                "numbase" => TypographyType.NumberBase,
                "hash" => TypographyType.hash,
                "translate" => TypographyType.googleTranslate,
                "nonsensify" => TypographyType.nonsensify,
                "caesar" => TypographyType.caesar,
                "caps" => TypographyType.capsRandomizer,
                "owoify" => TypographyType.owoify,
                "set" => TypographyType.set,
                "change" => TypographyType.change,
                "substring" => TypographyType.substring,
                "appendbehind" => TypographyType.appendBehind,
                "length" => TypographyType.length,
                "lowercase" => TypographyType.lowercase,
                "uppercase" => TypographyType.uppercase,
                "smallcaps" => TypographyType.smallcaps,
                "bold" => TypographyType.bold,
                "italics" => TypographyType.italics,
                "bolditalics" => TypographyType.bolditalics,
                "clear" => TypographyType.clear,
                "htmltxt" => TypographyType.htmlText,
                "call" => TypographyType.call,
                "delay" => TypographyType.delay,
                "if" => TypographyType.If,
                "1337" or "leet" => TypographyType.leetspeak,
                "galactic" => TypographyType.StandardGalacticAlphabet,
                "british" => TypographyType.british,
                "numeric" => TypographyType.numericAlphabet,
                "braille" => TypographyType.braille,
                "math" or "maths" => TypographyType.math,
                "badspelling" => TypographyType.badspelling,
                "print" => TypographyType.print,
                "background" => TypographyType.background,
                "showtutorial" => TypographyType.showtutorial,
                "debug" => TypographyType.debug,
                "wordshift" => TypographyType.wordShift,
                "discordtime" => TypographyType.discordtime,
                "sprinkle" => TypographyType.sprinkle,
                "superscript" => TypographyType.superscript,
                "unicodechars" => TypographyType.parseUnicodeChars,
                "parsevars" => TypographyType.parseVars,
                "increase" => TypographyType.increase,
                "callmethodfor" => TypographyType.callmethodfor,
                "repeatuntilover" => TypographyType.repeatuntilover,
                "unicrush" or "crush" => TypographyType.unicrush,
                "" or " " => TypographyType.None,
                _ => TypographyType.error,
            };
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
        sprinkle,
        superscript,
        parseUnicodeChars,
        parseVars,
        increase,
        callmethodfor,
        repeatuntilover,
        unicrush,
    }
}
