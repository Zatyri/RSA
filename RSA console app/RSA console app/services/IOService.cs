using RSA_console_app.models;
using System;
using System.Collections.Generic;
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
                    Console.WriteLine("Directory does not exist. Provide an existing directory or leave empty");
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
                    Console.WriteLine("File not found. Please provide correct path to file");
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
        /// <returns></returns>
        public static int GetBitSize()
        {
            Console.WriteLine("Give key bit size. (default = 1024)");

            int bitSize = 1024;
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
                    Console.WriteLine("Please provide a valid number");
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


    }
}
