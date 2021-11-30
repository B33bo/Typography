using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{
    public static class Tst
    {
        public static bool Test()
        {
            string str = "";

            foreach (var item in Enum.GetValues<TypographyType>())
            {
                if (item == TypographyType.nonsensify || item == TypographyType.test)
                    continue;

                Console.WriteLine($"Testing {item.ToReadableString()}");
                Typography.DoTypographyType(item, str, Array.Empty<string>());
            }

            return true;
        }
    }
}
