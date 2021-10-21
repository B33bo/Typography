using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typography.Meta;

namespace Typography
{
    public static class Hashing
    {
        public static string Hash_SHA1(string input)
        {
            // Create a SHA256   
            using SHA1 sha1Hash = SHA1.Create();

            // ComputeHash - returns byte array  
            byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert byte array to a string   
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string Hash_SHA256(string input)
        {
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert byte array to a string   
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string Hash_SHA384(string input)
        {
            // Create a SHA256   
            using SHA384 sha384Hash = SHA384.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert byte array to a string   
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string Hash_SHA512(string input)
        {
            // Create a SHA256   
            using SHA512 sha512Hash = SHA512.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert byte array to a string   
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string Hash_MD5(string input)
        {
            // Create a SHA256   
            using MD5 md5Hash = MD5.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert byte array to a string   
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string Hash(string input, string algorithm)
        {
            new ProgressBar($"Hash ({input})", 1, 1).Print();
            switch (algorithm.ToLower())
            {
                default:
                    Program.Error($"{algorithm} is not a hashing algorithm");
                    return input;
                case "sha1":
                    return Hash_SHA1(input);
                case "sha256":
                    return Hash_SHA256(input);
                case "sha384":
                    return Hash_SHA384(input);
                case "sha512":
                    return Hash_SHA512(input);
                case "md5":
                    return Hash_MD5(input);
            }
        }
    }
}
