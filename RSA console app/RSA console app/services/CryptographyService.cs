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

            plaintext = AddPKSCPadding(plaintext, publicKey.n.GetByteCount());

            BigInteger plaintextAsNumber = new BigInteger(plaintext);
            
            if (plaintextAsNumber >= publicKey.n)
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

            BigInteger decryptedCipher = BigInteger.ModPow(messageAsNumber, privateKey.d, privateKey.n);

            byte[] messageAsByteArray = RemovePKSCPadding(decryptedCipher.ToByteArray());

            string decodedMessage = ASCIIEncoding.UTF8.GetString(messageAsByteArray);


            return decodedMessage;
        }


        /// <summary>
        /// Adds PKSC#1.5 padding to the message
        /// </summary>
        /// <param name="message">Message to add padding to</param>
        /// <param name="sizeOfN">Size of n</param>
        /// <returns>The inputted message with padding</returns>
        /// <exception cref="Exception">If messag etoo long for given size of n</exception>
        internal static byte[] AddPKSCPadding(byte[] message, long sizeOfN)
        {
            if((message.Length + 11) > sizeOfN)
            {
                throw new Exception("Message too long for given public key");
            }
            long randomBits = sizeOfN - (message.Length + 3) ;
            byte[] padding = new byte[randomBits];
            Random random = new Random();

            padding[0] = 0x00;
            padding[1] = 0x02;

            for(int i = 2; i < padding.Length - 1; i++)
            {                                   
                padding[i] = (byte)random.Next(1,256);
            }

            padding[padding.Length - 1] = 0x00;

            byte[] paddedMessage = padding.Concat(message).ToArray();

            return paddedMessage;
        }

        /// <summary>
        /// Removes PKSC#1.5 from message
        /// </summary>
        /// <param name="paddedMessage">The message to remove padding from</param>
        /// <returns>The message without padding</returns>
        /// <exception cref="Exception">If message not properly formatted</exception>
        internal static byte[] RemovePKSCPadding(byte[] paddedMessage)        {

            if (paddedMessage[0] != (Byte)0x00 || paddedMessage[1] != (Byte)0x02)
            {
                throw new Exception("Message is not padded or has invalid formatting");
            }

            int messageStartsAtIndex = Array.IndexOf(paddedMessage, (Byte)0x00, 1) + 1;

            byte[] message = paddedMessage[messageStartsAtIndex..];

            return message;
        }
    }
}
