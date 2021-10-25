using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{
    public static class RandomWordCreator
    {
        public static string GenerateRandomWord()
        {
            Random rnd = new();
            int layers = rnd.Next(3, 5);

            string Value = "";
            for (int i = 0; i < layers; i++)
            {
                int Chars = rnd.Next(1, 4);
                for (int j = 0; j < Chars; j++)
                {
                    Value += AlphabetAndWords.consonants[rnd.Next(0, AlphabetAndWords.consonants.Length)];
                }

                Value += AlphabetAndWords.vowels[rnd.Next(0, AlphabetAndWords.vowels.Length)];
            }
            return Value;
        }
    }
}
