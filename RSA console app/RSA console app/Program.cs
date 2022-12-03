﻿using System;
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

            KeyGeneration keyGenerator = new KeyGeneration();

            Console.WriteLine("Welcome to RSA console app");
            while (!closeApp)
            {

                switch (Console.ReadLine())
                {
                    case "keys":
                        try
                        {
                            int bitSize = IOService.GetBitSize();
                            keyBaseDirectory = IOService.GetPath("keys");

                            (PublicKey, PrivateKey) keyPair = keyGenerator.GetPublicAndPrivateKeyPair(bitSize);

                            FileService.WritePublicKey(keyPair.Item1, keyBaseDirectory);
                            FileService.WritePrivateKey(keyPair.Item2, keyBaseDirectory);

                            Console.WriteLine($"New public and private keypair generated at \"{keyBaseDirectory}\"");
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine($"Error generating keys. Please try again. ({e.Message})");
                        }

                        break;
                    case "encrypt":
                        try
                        {
                            string publicKeyPath = IOService.GetPath("public key");
                            PublicKey publicKey = FileService.ReadPublicKey(publicKeyPath);
                            string messagePath = IOService.GetPath("encrypted message");
                            string message = IOService.GetMessageToEncrypt();

                            string encryptedMessage = CryptographyService.EncryptMessage(message, publicKey);
                            messagePath = FileService.WriteMessage(encryptedMessage, messagePath);

                            Console.WriteLine($"Message \"{message}\" has been encrypted and saved to \"{messagePath}\"");
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine($"Error encrypting message. Please try again. ({e.Message})");
                        }
                        break;
                    case "decrypt":
                        try
                        {
                            string privateKeyPath = IOService.GetPath("private key");
                            PrivateKey privateKey = FileService.ReadPrivateKey(privateKeyPath);

                            string encryptedMessagePath = IOService.GetFilePath("encrypted");
                            string messageToDecrypt = FileService.ReadMessage(encryptedMessagePath);
                            string decyptedMessage = CryptographyService.DecryptMessage(messageToDecrypt, privateKey);

                            Console.WriteLine($"Message decrypted: {decyptedMessage}");
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine($"Error decrypting message. Please try again. ({e.Message})");
                            ;
                        }

                        break;
                    case "test":
                        try
                        {
                            int primeBitSize = IOService.GetBitSize(512, "Give prime bit size");
                            int testRounds = IOService.GetBitSize(20, "How many test runs? ");
                            bool usePreCheck = IOService.GetBoolean("Use prime pre check functionality?", true);
                            int rounds = IOService.GetBitSize(40, "How many Miller-Rabin checks on each prime candidate");
                            PrimeService.TestPrimeAlgorithm(primeBitSize, rounds: rounds, testAmount: testRounds, usePreCheck: usePreCheck); ;
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine($"Error running tests. Please try again. ({e.Message})");
                        }
                        break;
                    case "help":
                        Console.WriteLine("Commands:");
                        Console.WriteLine("Generate public and private keypair: \"keys\"");
                        Console.WriteLine("Encrypt message: \"encrypt\"");
                        Console.WriteLine("Decrypt message: \"decrypt\"");
                        Console.WriteLine("Perform algorithm tests: \"test\"");
                        Console.WriteLine("Exit application: \"exit\"");
                        break;
                    case "exit":
                        closeApp = true;
                        break;
                    default:
                        Console.WriteLine("Need help? type \"help\"");
                        break;
                }
            }
        }
    }
}