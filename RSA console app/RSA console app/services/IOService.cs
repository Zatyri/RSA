using RSA_console_app.models;
using SandcastleBuilder.Utils;
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
    public class IOService
    {
        private KeyGeneration _keyGenerator;
        
        /// <summary>
        /// Constructor for the IOService
        /// </summary>
        /// <param name="keyGenerator">The key generator</param>
        public IOService(KeyGeneration keyGenerator)
        {
            _keyGenerator = keyGenerator;            
        }

        /// <summary>
        /// Generates public and private key of desired bit size to desired directory
        /// </summary>
        public string GenerateKeyPair()
        {
            int bitSize = GetBitSize();
            string? path = GetPath();
            (PublicKey, PrivateKey) keyPair = _keyGenerator.GetPublicAndPrivateKeyPair(bitSize);
            FileService.WritePublicKey(keyPair.Item1, path);
            FileService.WritePrivateKey(keyPair.Item2, path);

            return string.IsNullOrEmpty(path) ? "" : path;
        }

        /// <summary>
        /// Gets the path for key files from the user
        /// </summary>
        /// <returns>The path as a string</returns>
        private string? GetPath()
        {
            Console.WriteLine("Provide a existing directory for keys (leave empty for program root dir):");

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
            return string.IsNullOrEmpty(path) ? null : path;
        }

        /// <summary>
        /// Gets the desired key bit size from the user
        /// </summary>
        /// <returns></returns>
        private int GetBitSize()
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
    }
}
