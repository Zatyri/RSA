using RSA_console_app.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.services
{
    /// <summary>
    /// Class for reading and writing to files
    /// </summary>
    public class FileService
    {
        internal static void WritePublicKey(PublicKey publicKey, string? path = null)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(path) && !Directory.Exists(path))
                {
                    throw new FileNotFoundException("Given path does not exist");
                }

                path = string.IsNullOrWhiteSpace(path) ? "key.pub" : $"{path}/key.pub";

                string[] lines =
                {
                "----BEGIN PUBLIC KEY----",
                Convert.ToBase64String(publicKey.e.ToByteArray()),
                Convert.ToBase64String(publicKey.n.ToByteArray()),
                "----END PUBLIC KEY----"
                };


                File.WriteAllLines(path, lines);
            }
            catch (Exception e)
            {
                throw new Exception($"Error writing public key to file. {e.ToString()}");
            }
        }

        internal static PublicKey ReadPublicKey(string? path = null)
        {
            try
            {
                path = string.IsNullOrWhiteSpace(path) ? "key.pub" : $"{path}/key.pub";

                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"Public key does not exist at: {path}");
                }

                string[] lines = File.ReadAllLines(path);

                if (!lines[0].Equals("----BEGIN PUBLIC KEY----") || 
                    !lines[lines.Length - 1].Equals("----END PUBLIC KEY----"))
                {
                    throw new Exception("Public key file not properly formatted");
                }

                BigInteger e = new BigInteger(Convert.FromBase64String(lines[1]));

                int i = 2;
                string key = "";
                while (!lines[i].Equals("----END PUBLIC KEY----"))
                {
                    key = key + lines[i];
                    i++;
                }
                BigInteger n = new BigInteger(Convert.FromBase64String(key));

                return new PublicKey(n, e, -1);
            }
            catch (Exception e)
            {
                throw new Exception($"Error reading public key from file. {e.ToString()}");
            }
        }

        internal static void WritePrivateKey(PrivateKey privateKey, string? path = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && !Directory.Exists(path))
                {
                    throw new FileNotFoundException("Given path does not exist");
                }

                path = string.IsNullOrWhiteSpace(path) ? "key.priv" : $"{path}/key.priv";

                string[] lines =
            {
                "----BEGIN PRIVATE KEY----",
                Convert.ToBase64String(privateKey.d.ToByteArray()),
                Convert.ToBase64String(privateKey.n.ToByteArray()),
                "----END PRIVATE KEY----"
            };

                File.WriteAllLines(path, lines);
            }
            catch (Exception e)
            {
                throw new Exception($"Error writing private key to file. {e.ToString()}");
            }
        }

        internal static PrivateKey ReadPrivateKey(string? path = null)
        {
            try
            {
                path = string.IsNullOrWhiteSpace(path) ? "key.priv" : $"{path}/key.priv";

                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"Private key does not exist at: {path}");
                }

                string[] lines = File.ReadAllLines(path);

                if (!lines[0].Equals("----BEGIN PRIVATE KEY----") ||
                    !lines[lines.Length - 1].Equals("----END PRIVATE KEY----"))
                {
                    throw new Exception("Private key file not properly formatted");
                }

                BigInteger d = new BigInteger(Convert.FromBase64String(lines[1]));

                int i = 2;
                string key = "";
                while (!lines[i].Equals("----END PRIVATE KEY----"))
                {
                    key = key + lines[i];
                    i++;
                }
                BigInteger n = new BigInteger(Convert.FromBase64String(key));

                return new PrivateKey(d, n);
            }
            catch (Exception e)
            {
                throw new Exception($"Error reading private key from file. {e.ToString()}");
            }
        }

        internal static string WriteMessage(string message, string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && !Directory.Exists(path))
                {
                    throw new FileNotFoundException("Given path does not exist");
                }

                path = string.IsNullOrWhiteSpace(path) ? $"{Directory.GetCurrentDirectory()}\\message.txt" : $"{path}\\message.txt";

                File.WriteAllText(path, message);               

                return path;
            }
            catch (Exception e)
            {
                throw new Exception($"Error writing message to file. {e.ToString()}");
            }
        }

        internal static string ReadMessage(string path)
        {
            try
            {               
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"Message does not exist at: {path}");
                }

                string[] lines = File.ReadAllLines(path);
                string message = String.Join("", lines);

                return message;
                
            }
            catch (Exception e)
            {
                throw new Exception($"Error reading private key from file. {e.ToString()}");
            }
        }
    }
}
