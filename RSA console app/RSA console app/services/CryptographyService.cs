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
    /// Class for encrypting and decrypting messages
    /// </summary>
    public static class CryptographyService
    {

        /// <summary>
        /// Encrypts message with given public key
        /// </summary>
        /// <param name="messageToEncrypt">The message to encrypt</param>
        /// <param name="publicKey">The publick key to encrypt the message</param>
        /// <returns>The encrypted message as string</returns>
        /// <exception cref="Exception">If message is too long for given key</exception>
        public static string EncryptMessage(string messageToEncrypt, PublicKey publicKey)
        {
            byte[] plaintext = ASCIIEncoding.UTF8.GetBytes(messageToEncrypt);

            BigInteger plaintextAsNumber = new BigInteger(plaintext);

            if (plaintextAsNumber > publicKey.n)
            {
                throw new Exception("Message too long for given key");
            }

            BigInteger encryptedNumber = BigInteger.ModPow(plaintextAsNumber, publicKey.e, publicKey.n);

            return Convert.ToBase64String(encryptedNumber.ToByteArray());
        }
        /// <summary>
        /// Decrypts the given encrypted message with given private key
        /// </summary>
        /// <param name="encryptedMessage">The message to decrypt</param>
        /// <param name="privateKey">The private key to decrypt the message with</param>
        /// <returns>The decryted message</returns>
        public static string DecryptMessage(string encryptedMessage, PrivateKey privateKey)
        {
            byte[] messageAsBytes = Convert.FromBase64String(encryptedMessage);

            BigInteger messageAsNumber = new BigInteger(messageAsBytes);

            BigInteger dc = BigInteger.ModPow(messageAsNumber, privateKey.d, privateKey.n);

            string decodedMessage = ASCIIEncoding.UTF8.GetString(dc.ToByteArray());

            return decodedMessage;
        }
    }
}
