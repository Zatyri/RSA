using RSA_console_app.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.services
{
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

            //return Convert.ToBase64String(encryptedNumber.ToByteArray());
            return encryptedNumber.ToString();
        }

        public static string DecryptMessage(string encryptedMessage, PrivateKey privateKey)
        {
            //byte[] messageAsBytes = Convert.FromBase64String(encryptedMessage);
            //byte[] messageAsBytes = BigInteger.Parse(encryptedMessage).ToByteArray();

            //BigInteger messageAsNumber = new BigInteger(messageAsBytes);
            BigInteger messageAsNumber = BigInteger.Parse(encryptedMessage);

            BigInteger dc = BigInteger.ModPow(messageAsNumber, privateKey.d, privateKey.n);

            //byte[] test = dc.ToByteArray();
            string decodedMessage = ASCIIEncoding.UTF8.GetString(dc.ToByteArray());

            return decodedMessage;
        }
    }
}
