using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Typography.Meta
{
    public static class TypographyExtention
    {
        public static T SafeGet<T>(this T[] array, int index, T defaultValue)
        {
            if (array.Length == 0)
            {
                return defaultValue;
            }

            if (array.Length <= index)
            {
                return defaultValue;
            }

            return array[index];
        }

        public static T SafeGet<T>(this T[] array, int index)
        {
            if (array.Length == 0)
            {
                Program.Error("Not any params (0)");

                if (typeof(T) == typeof(string))
                    return (T)Convert.ChangeType("", typeof(T));

                return default;
            }

            if (array.Length <= index)
            {
                Program.Error($"{array[0]} does not have enough params ({array.Length})");

                if (typeof(T) == typeof(string))
                    return (T)Convert.ChangeType("", typeof(T));

                return default;
            }

            return array[index];
        }

        public static string ToString(this char[] input)
        {
            string returnValue = "";
            foreach (var item in input)
            {
                returnValue += item;
            }

            return returnValue;
        }

        public static string ToRealString(this string[] input, char seperator)
        {
            string returnValue = "";
            foreach (var item in input)
            {
                returnValue += seperator + item;
            }

            return returnValue[1..];
        }

        public static string ToRealString(this List<string> input, char seperator)
        {
            if (input.Count == 0)
                return "";

            string returnValue = "";
            foreach (var item in input)
            {
                returnValue += seperator + item;
            }

            return returnValue[1..];
        }

        public static Dictionary<TValue, TKey> FlipDict<TKey, TValue>(this Dictionary<TKey, TValue> input)
        {
            List<TKey> keys = input.Keys.OfType<TKey>().ToList();
            List<TValue> values = input.Values.OfType<TValue>().ToList();

            Dictionary<TValue, TKey> returnValue = new();

            for (int i = 0; i < keys.Count; i++)
            {
                if (returnValue.ContainsKey(values[i]))
                    continue;

                returnValue.Add(values[i], keys[i]);
            }

            return returnValue;
        }

        public static char ToLower(this char str)
        {
            return Char.ToLower(str);
        }

        public static char ToUpper(this char str)
        {
            return Char.ToUpper(str);
        }

        public static bool IsTrue(this string str)
        {
            if (str.Length == 0)
                return false;

            if (str.ToLower()[0] == 'e')
                return true;

            if (str.ToLower() == "true")
                return true;

            if (str.ToLower()[0] == 'y')
                return true;

            if (str.ToLower() == "on")
                return true;

            if (double.TryParse(str, out double result))
                if (result == 1)
                    return true;

            return false;
        }

        public static int IndexOf<T>(this T[] input, T item)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(input[i], item))
                    return i;
            }

            return -1;
        }

        public static string GetPathFromPartial(string RelativeLoc)
        {
            List<string> currentDir = System.Reflection.Assembly.GetEntryAssembly().Location.Split(@"\").ToList();

            currentDir.RemoveAt(currentDir.Count - 1);
            string path = currentDir.ToRealString('\\');
            return path + @"\" + RelativeLoc;
        }
    }
}
