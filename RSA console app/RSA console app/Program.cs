using System;
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
            KeyGeneration keyGeneration = new KeyGeneration(new PrimeService());

            (PublicKey, PrivateKey) keyPair = keyGeneration.GetPublicAndPrivateKeyPair(1024);

            FileService.WritePublicKey(keyPair.Item1);
            FileService.WritePrivateKey(keyPair.Item2);
            PublicKey publicKey = FileService.ReadPublicKey();
            PrivateKey privateKey = FileService.ReadPrivateKey();

            string message = "Hello World! åäö";

            byte[] plaintext = ASCIIEncoding.UTF8.GetBytes(message);
            BigInteger pt = new BigInteger(plaintext);
            if (pt > publicKey.n)
                throw new Exception();
            Console.WriteLine("before:  " + pt);

            BigInteger ct = BigInteger.ModPow(pt, publicKey.e, publicKey.n);
            //Console.WriteLine("Encoded:  " + ct);
            Console.WriteLine(ASCIIEncoding.UTF8.GetString(ct.ToByteArray()));

            BigInteger dc = BigInteger.ModPow(ct, privateKey.d, privateKey.n);
            Console.WriteLine("Decoded:  " + dc);
            
            string decoded = ASCIIEncoding.UTF8.GetString(dc.ToByteArray());
            Console.WriteLine("As ASCII: " + decoded);

        }

        
    }
}