using System;

namespace Typography
{
    public static class ConvertToHashtable
    {
        public static string Encode(string Input)
        {
            ProgressBar bar = new ProgressBar("Big letters to dict", Input.Length);
            Console.WriteLine("SECRET CONVERT TO DICT FOUND");
            string returnValue = "";
            string[] lines = Input.Split('\n');
            int itersSinceLastChar = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                bar.Increase();
                if (lines[i] == "\n" || lines[i] == "" || lines[i] == " " || lines[i] == "\r")
                    continue;

                if (itersSinceLastChar == 0)
                    returnValue += "{\"";

                lines[i] = lines[i].Replace("\n", "").Replace("\r", ""); //remove newlines

                if (itersSinceLastChar == 0)
                    returnValue += $"{lines[i]}\",";
                else if (itersSinceLastChar != 4)
                    returnValue += $" @\"{lines[i]}\" + \"\\n \" + ";

                if (itersSinceLastChar == 4)
                {
                    returnValue += $" @\"{lines[i]}\"" + "},\n\n";
                    itersSinceLastChar = -1;
                }
                else
                    returnValue += "\n";

                itersSinceLastChar++;
            }

            return returnValue;
        }
    }
}