using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Text.Unicode;
using System.Transactions;
using RSA_console_app.models;
using RSA_console_app.services;

namespace RSA_console_app
{
    class Program
    {

        static void Main(string[] args)
        {
            bool closeApp = false;
            string keyBaseDirectory = "";

            KeyGeneration keyGenerator = new KeyGeneration(new PrimeService());

            Console.WriteLine("Welcome to RSA console app");
            while (!closeApp)
            {

                switch (Console.ReadLine())
                {
                    case "keys":
                        int bitSize = IOService.GetBitSize();
                        keyBaseDirectory = IOService.GetPath("keys");

                        (PublicKey, PrivateKey) keyPair = keyGenerator.GetPublicAndPrivateKeyPair(bitSize);

                        FileService.WritePublicKey(keyPair.Item1, keyBaseDirectory);
                        FileService.WritePrivateKey(keyPair.Item2, keyBaseDirectory);

                        Console.WriteLine($"New public and private keypair generated at \"{keyBaseDirectory}\"");

                        break;
                    case "encrypt":
                        string publicKeyPath = IOService.GetPath("public key");
                        PublicKey publicKey = FileService.ReadPublicKey(publicKeyPath);
                        string messagePath = IOService.GetPath("encrypted message");
                        string message = IOService.GetMessageToEncrypt();

                        string encryptedMessage = CryptographyService.EncryptMessage(message, publicKey);
                        messagePath = FileService.WriteMessage(encryptedMessage, messagePath);

                        Console.WriteLine($"Message \"{message}\" has been encrypted and saved to \"{messagePath}\"");
                        break;
                    case "decrypt":
                        string privateKeyPath = IOService.GetPath("private key");
                        PrivateKey privateKey = FileService.ReadPrivateKey(privateKeyPath);

                        string encryptedMessagePath = IOService.GetFilePath("encrypted");
                        string messageToDecrypt = FileService.ReadMessage(encryptedMessagePath);
                        string decyptedMessage = CryptographyService.DecryptMessage(messageToDecrypt, privateKey);

                        Console.WriteLine($"Message decrypted: {decyptedMessage}");

                        break;
                    case "help":
                        Console.WriteLine("Help is on the way");
                        break;
                    case "exit":
                        closeApp = true;
                        break;
                    default:
                        Console.WriteLine("Need help?");
                        break;
                }
            }
        }
    }
}