using System;
using System.Collections.Generic;
using System.Linq;

namespace Typography
{
    public static class BackwardsText
    {
        public static string Flip(string Input)
        {
            return Input.Reverse().ToArray().toString();
        }
    }

    public static class Randomize
    {
        public static string Jumble(string Input)
        {
            List<int> indexesAllowed = new List<int>();

            for (int i = 0; i < Input.Length; i++)
                indexesAllowed.Add(i);

            Console.WriteLine(indexesAllowed.Count);
            string returnValue = "";
            for (int i = 0; i < Input.Length; i++)
            {
                Random rng = new Random();
                int newRandomIndex = indexesAllowed[rng.Next(0, indexesAllowed.Count)];
                returnValue += Input[newRandomIndex];
                indexesAllowed.Remove(newRandomIndex);
            }

            return returnValue;
        }
    }

    public static class Append
    {
        public static string ToEncoded(string Input, string append)
        {
            return Input + append;
        }

        public static string FromEncoded(string Input, string append)
        {
            return Input.Substring(0, Input.Length - append.Length);
        }
    }
}