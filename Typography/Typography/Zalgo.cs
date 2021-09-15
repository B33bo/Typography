using System;
using System.Linq;

namespace Typography
{
    //Credit:: https://github.com/marfgold1/ZalgoCSharp/blob/master/ZalgoOnline.cs
    public class Zalgo
    {
        static char[] zalgoUp = {
            (char)0x030d,       (char)0x030e,       (char)0x0304,       (char)0x0305,
            (char)0x033f,       (char)0x0311,       (char)0x0306,       (char)0x0310,
            (char)0x0352,       (char)0x0357,       (char)0x0351,       (char)0x0307,
            (char)0x0308,       (char)0x030a,       (char)0x0342,       (char)0x0343,
            (char)0x0344,       (char)0x034a,       (char)0x034b,       (char)0x034c,
            (char)0x0303,       (char)0x0302,       (char)0x030c,       (char)0x0350,
            (char)0x0300,       (char)0x0301,       (char)0x030b,       (char)0x030f,
            (char)0x0312,       (char)0x0313,       (char)0x0314,       (char)0x033d,
            (char)0x0309,       (char)0x0363,       (char)0x0364,       (char)0x0365,
            (char)0x0366,       (char)0x0367,       (char)0x0368,       (char)0x0369,
            (char)0x036a,       (char)0x036b,       (char)0x036c,       (char)0x036d,
            (char)0x036e,       (char)0x036f,       (char)0x033e,       (char)0x035b,
        };

        static char[] zalgoDown = {
            (char)0x0316,       (char)0x0317,       (char)0x0318,       (char)0x0319,
            (char)0x031c,       (char)0x031d,       (char)0x031e,       (char)0x031f,
            (char)0x0320,       (char)0x0324,       (char)0x0325,       (char)0x0326,
            (char)0x0329,       (char)0x032a,       (char)0x032b,       (char)0x032c,
            (char)0x032d,       (char)0x032e,       (char)0x032f,       (char)0x0330,
            (char)0x0331,       (char)0x0332,       (char)0x0333,       (char)0x0339,
            (char)0x033a,       (char)0x033b,       (char)0x033c,       (char)0x0345,
            (char)0x0347,       (char)0x0348,       (char)0x0349,       (char)0x034d,
            (char)0x034e,       (char)0x0353,       (char)0x0354,       (char)0x0355,
            (char)0x0356,       (char)0x0359,       (char)0x035a,       (char)0x0323
        };

        static char[] zalgoMid = {
            (char)0x0315,       (char)0x031b,       (char)0x0340,       (char)0x0341,
            (char)0x0358,       (char)0x0321,       (char)0x0322,       (char)0x0327,
            (char)0x0328,       (char)0x0334,       (char)0x0335,       (char)0x0336,
            (char)0x034f,       (char)0x035c,       (char)0x035d,       (char)0x035e,
            (char)0x035f,       (char)0x0360,       (char)0x0362,       (char)0x0338,
            (char)0x0337,       (char)0x0361,       (char)0x0489
        };

        static Random rnd = new Random();

        static bool isZalgoChar(char input)
        {
            if (zalgoUp.Contains(input))
                return true;

            if (zalgoMid.Contains(input))
                return true;

            if (zalgoDown.Contains(input))
                return true;

            return false;
        }

        public static string Encode(string Input, uint numUp = 15, uint numMid = 15, uint numDown = 15)
        {
            ProgressBar bar = new ProgressBar("Zalgo (encode)", (int)((numUp * numMid * numDown) * (uint)Input.Length));
            string returnValue = "";

            for (int i = 0; i < Input.Length; i++)
            {
                if (isZalgoChar(Input[i]))
                {
                    bar.Increase(3);
                    continue;
                }

                returnValue += Input[i];

                if (Input[i] == '\r' || Input[i] == '\n')
                {
                    bar.Increase(3);
                    continue;
                }

                for (int j = 0; j < numUp; j++)
                {
                    returnValue += getZalgoChar(zalgoUp, (uint)zalgoUp.Length);
                    bar.Increase();
                }

                for (int j = 0; j < numMid; j++)
                {
                    returnValue += getZalgoChar(zalgoMid, (uint)zalgoMid.Length);
                    bar.Increase();
                }

                for (int j = 0; j < numDown; j++)
                {
                    returnValue += getZalgoChar(zalgoDown, (uint)zalgoDown.Length);
                    bar.Increase();
                }
            }

            return returnValue;
        }

        public static string Decode(string Input)
        {
            ProgressBar bar = new ProgressBar("Zalgo (decode)", Input.Length);
            string returnVal = "";
            for (int i = 0; i < Input.Length; i++)
            {
                bar.Increase();

                if (isZalgoChar(Input[i]))
                    continue;
                else
                    returnVal += Input[i];
            }

            return returnVal;
        }

        static char getZalgoChar(char[] arr, uint n)
        {
            int index = rnd.Next((int)n);
            return arr[index];
        }
    }
}
