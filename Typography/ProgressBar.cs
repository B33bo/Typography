using System;
using System.Threading;
using System.Diagnostics;

namespace Typography
{
    public class ProgressBar
    {
        public static string emptySquare = "-";
        public static string filledSquare = "#";

        public int Value { get; set; }
        public int MaxValue { get; private set; }
        public Stopwatch stopwatch { get; private set; } = new Stopwatch();

        public string ProcessName = "Unnamed";

        public float Percentage
        {
            get
            {
                if (MaxValue == 0)
                    return 1;

                return Value / (float)MaxValue;
            }
        }

        private void Start()
        {
            stopwatch.Start();
        }

        public void Increase(int amount = 1)
        {
            Value += amount;

            if (MaxValue <= 100)
                Print();

            else
            {
                if (Value % 10 == 0)
                    Print();
            }
        }

        public override string ToString()
        {
            uint chunks = Settings.ProgressBarBlocks;
            int ChunksToFill = (int)MathF.Floor(Percentage * chunks);

            if (MaxValue == 0)
                ChunksToFill = (int)chunks;

            string ProgressValue = "";

            for (int i = 0; i < chunks; i++)
            {
                ProgressValue += i > ChunksToFill ? emptySquare : filledSquare;
            }

            return $"[{ProgressValue}] {ProcessName} time = {stopwatch.ElapsedMilliseconds} % = {Percentage}";
        }

        public void Print()
        {
            Console.CursorLeft = 0;
            Console.Write(ToString());
        }

        public ProgressBar()
        {
            Value = 0;
            MaxValue = 10;
        }

        public ProgressBar(string processName, int maxValue)
        {
            ProcessName = processName;
            Value = 0;
            MaxValue = maxValue;

            Start();
        }

        public ProgressBar(string processName, int value, int maxValue)
        {
            ProcessName = processName;
            Value = value;
            MaxValue = maxValue;
        }
    }
}
