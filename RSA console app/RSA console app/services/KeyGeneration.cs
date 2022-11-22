﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RSA_console_app.models;

namespace RSA_console_app.services
{
    /// <summary>
    /// Class for generating public and private key pair
    /// </summary>
    public class KeyGeneration
    {
        private PrimeService primeService;

        /// <summary>
        /// The constructor for the key generation class
        /// </summary>
        /// <param name="primeService">A service that generates primes</param>
        public KeyGeneration(PrimeService primeService)
        {
            this.primeService = primeService;
        }

        /// <summary>
        /// Generates a public key with desired bit size
        /// </summary>
        /// <param name="bitSize">The desired bit size of the key</param>
        /// <returns>A public key with desired bit size</returns>
        internal PublicKey GeneratePublicKey(int bitSize)
        {
            BigInteger[] primes = primeService.GetTwoPrimes(bitSize / 2);

            BigInteger n = primes[0] * primes[1];

            BigInteger e = 65537;
            BigInteger phi = (primes[0] - 1) * (primes[1] - 1);

            while (e < phi)
            {
                if (Helpers.gcd(e, phi) == 1)
                {
                    break;
                }
                else
                {
                    e++;
                }
            }

            return new PublicKey(n, e, phi);
        }

        /// <summary>
        /// Generates a private key for a given public key
        /// </summary>
        /// <param name="publicKey">The public key to be paired with the private key</param>
        /// <returns>A private key</returns>
        internal PrivateKey GeneratePrivateKey(PublicKey publicKey)
        {
            BigInteger d = 0;
            int i = 0;
            while (true)
            {
                BigInteger a;
                BigInteger times = publicKey.phi * i + 1;
                BigInteger b = BigInteger.DivRem(times, publicKey.e, out a);
                if (a == 0)
                {
                    d = b;
                    break;
                }
                i++;
            }
            return new PrivateKey(d, publicKey.n);
        }

        /// <summary>
        /// Creates a public and private key pair
        /// </summary>
        /// <param name="bitSize">The size in bits of the keys generated</param>
        /// <returns>A tuple with the public and private key</returns>
        public (PublicKey, PrivateKey) GetPublicAndPrivateKeyPair(int bitSize)
        {
            PublicKey publicKey = GeneratePublicKey(bitSize);
            PrivateKey privateKey = GeneratePrivateKey(publicKey);

            return new(publicKey, privateKey);
        }
    }
}