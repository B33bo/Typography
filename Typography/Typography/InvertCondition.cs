using System;
using System.Collections.Generic;
using System.Linq;

namespace Typography
{
    public static class InvertCondition
    {
        public static string FlipCondition(string Input)
        {
            ProgressBar bar = new ProgressBar("Flip Condition", 1);

            Input = Input.ToLower();
            Condition input;

            if (!Enum.TryParse(Input, out input))
                input = getConditionFromOperator(Input);

            int ID_of_Input = (int)input;
            bar.Increase();

            if (ID_of_Input % 2 == 0) //Is an even number
                return ((Condition)ID_of_Input + 1).ToString();
            else
                return ((Condition)ID_of_Input - 1).ToString();
        }

        public static Condition getConditionFromOperator(string Operator)
        {
            Operator = Operator.ToLower();
            var res = getAsCsharpOperator.FlipDict();

            if (!res.ContainsKey(Operator))
            {
                Program.Error($"{Operator} is not a operator. please use something like 'and' or 'not'");
                return Condition.unknown;
            }
            return res[Operator];
        }

        public enum Condition
        {
            unknown,
            unknown2,

            excatly,
            not,

            equal,
            notequal,

            greater,
            lessequal,

            less,
            greaterequal,

            or,
            nor,

            and,
            nand,

            xor,
            xnor,
        }

        public static Dictionary<Condition, string> getAsCsharpOperator = new Dictionary<Condition, string>()
        {
            {Condition.unknown, "error"},
            {Condition.unknown2, "error2"},

            {Condition.excatly, ""},
            {Condition.not, "!"},

            {Condition.equal, "=="},
            {Condition.notequal, "!="},

            {Condition.greater, ">"},
            {Condition.lessequal, "<="},

            {Condition.less, "<"},
            {Condition.greaterequal, ">="},

            {Condition.or, "||"},
            {Condition.nor, "!(a||b)"},

            {Condition.and, "&&"},
            {Condition.nand, "!(a&&b)"},

            {Condition.xor, "^"},
            {Condition.xnor, "!(a^b)"},
        };
    }
}
