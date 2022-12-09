using RSA_console_app.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.services
{
    /// <summary>
    /// Class to handle IO to the CLI
    /// </summary>
    public static class IOService
    {
        
        /// <summary>
        /// Gets the path from user
        /// </summary>
        /// <returns>The path as a string</returns>
        public static string GetPath(string pathPurpose)
        {
            Console.WriteLine($"Provide an existing directory for {pathPurpose} (leave empty for program root dir):");

            string? path = null;
            while (true)
            {
                path = Console.ReadLine();

                if (string.IsNullOrEmpty(path)) break;


                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Directory does not exist. Provide an existing directory or leave empty for application root directory");
                }
                else
                {
                    break;
                }
            }
            return string.IsNullOrEmpty(path) ? Directory.GetCurrentDirectory() : path;
        }

        /// <summary>
        /// Gets the file from user
        /// </summary>
        /// <returns>The path to file as a string</returns>
        public static string GetFilePath(string pathPurpose)
        {
            Console.WriteLine($"Give path for {pathPurpose} file");

            string? path = null;
            while (true)
            {
                path = Console.ReadLine();

                if (string.IsNullOrEmpty(path)) break;


                if (!File.Exists(path))
                {
                    Console.WriteLine("File not found. Please provide an existing path to file");
                }
                else
                {
                    break;
                }
            }
            return string.IsNullOrEmpty(path) ? "" : path;
        }

        /// <summary>
        /// Gets the desired key bit size from the user
        /// </summary>
        /// <returns>The bitsize as an integer</returns>
        public static int GetBitSize(int def = 1024, string text = "Give key bit size.")
        {
            Console.WriteLine($"{text} (default = {def})");

            int bitSize = def;
            while (true)
            {
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) break;

                if(Int32.TryParse(input, out bitSize))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid number. Please provide a valid number. Valid numbers are positive integers");
                }

            }
            return bitSize;
        }

        /// <summary>
        /// Asks user for message to encryps
        /// </summary>
        /// <returns>The message that the user wants to encrypt</returns>
        public static string GetMessageToEncrypt()
        {
            string? message;

            while (true)
            {
                Console.WriteLine("Write message to encrypt:");

                message = Console.ReadLine();

                if (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("Message can not contain only spaces");
                } else
                {
                    break;
                }

            }
            return message;
        }

        /// <summary>
        /// Asks user for a boolean value (Yes or No)
        /// </summary>
        /// <param name="text">Guide text for what purpose value is asked</param>
        /// <param name="def">Default value (if nothing entered)</param>
        /// <returns>true if user replies "Yes", false if user replies "No"</returns>
        public static bool GetBoolean(string text, bool def)
        {
            Console.WriteLine($"{text} (default = {def})");
            bool value = def;
            while (true)
            {
                Console.WriteLine($"Press Y for Yes or N for No (blank = {(def ? "Yes" : "No")})");
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {                    
                    break;
                } else if (input.ToLower().Equals("y"))
                {
                    value = true;
                    break;
                } else if (input.ToLower().Equals("n"))
                {
                    value = false;
                    break;
                }
            }
            return value;
        }
        
        /// <summary>
        /// Get string input from user
        /// </summary>
        /// <param name="text">Text to display what string is used for</param>
        /// <param name="def">Default value</param>
        /// <returns>The userinput, or default value if empty</returns>
        public static string GetString(string text, string def)
        {
            Console.WriteLine($"{text} (default = {def})");
            string? value = Console.ReadLine();

            if (string.IsNullOrEmpty(value))
            {
                return def;
            }

            return value;
        }
    

    }
}
