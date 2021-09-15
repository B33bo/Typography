using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typography
{
    public static class Hashing
    {
        public static string e_sha1(string input)
        {
            // Create a SHA256   
            using (SHA1 sha1Hash = SHA1.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string e_sha256(string input)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string e_sha384(string input)
        {
            // Create a SHA256   
            using (SHA384 sha384Hash = SHA384.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string e_sha512(string input)
        {
            // Create a SHA256   
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string e_md5(string input)
        {
            // Create a SHA256   
            using (MD5 md5Hash = MD5.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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
                    return e_sha1(input);
                case "sha256":
                    return e_sha256(input);
                case "sha384":
                    return e_sha384(input);
                case "sha512":
                    return e_sha512(input);
                case "md5":
                    return e_md5(input);
            }
        }
    }
}
