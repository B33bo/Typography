using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class MathsSolve
    {
        public static double Value(double input, string Operator, double number)
        {
            switch (Operator.ToLower())
            {
                default:
                    return Program.Error($"{Operator} is not an operation", input);
                case "+":
                case "plus":
                case "add":
                    return input + number;
                case "-":
                case "minus":
                case "subtract":
                    return input - number;
                case "*":
                case "×":
                case "·":
                case "times":
                case "multiply":
                    return input * number;
                case "/":
                case "÷":
                case "divide":
                    return input / number;
                case "^":
                case "power":
                case "exponent":
                    return Math.Pow(input, number);
                case "√":
                case "root":
                case "surd":
                    return Math.Pow(input, 1 / number);
                case "2√":
                case "sqrt":
                case "square root":
                    return Math.Sqrt(input);
                case "||":
                case "|x|":
                case "abs":
                    return Math.Abs(input);
                case "!":
                case "factorial":
                    try
                    {
                        return Factorial((uint)input);
                    }
                    catch (InvalidCastException)
                    {
                        return Program.Error($"{input} is not a positive integer!", input);
                    }
                case "sin":
                case "sine":
                    return Math.Sin(input);
                case "cos":
                case "cosine":
                    return Math.Cos(input);
                case "tan":
                case "tangent":
                    return Math.Tan(input);
                case "log":
                case "logaritm":
                    return Math.Log(input, number);
                case ">":
                case "greater":
                    return input > number ? 1 : 0;
                case "<":
                case "less":
                    return input < number ? 1 : 0;
                case ">=":
                case "greaterequal":
                    return input >= number ? 1 : 0;
                case "<=":
                case "lessequal":
                    return input <= number ? 1 : 0;
                case "=":
                case "==":
                case "equal":
                    return input == number ? 1 : 0;
                case "?":
                case "random":
                    Random random = new();
                    return random.NextDouble() * (input - number) + number;
            }
        }

        public static double Value(double input, string Operator)
        {
            return Value(input, Operator, 0);
        }

        public static uint Factorial(uint input)
        {
            if (input == 0)
                return 1;
            else
                return input * Factorial(input - 1);
        }
    }
}
