﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app
{
    public class PrimeService
    {
        public int GetPrime()
        {
            BigInteger[] randomNumbers = GetTwoRandomOddNumbers(512);
            return 17;
        }

        public bool IsNumberPrime(BigInteger primeCandidate, int rounds)
        {
            if (primeCandidate == 2 || primeCandidate == 3)
                return true;
            if (primeCandidate < 2 || primeCandidate % 2 == 0)
                return false;

            BigInteger d = CalculateInitialPowerValue(primeCandidate - 1);


            for (int i = 0; i < rounds; i++)
            {

            }
            // There is no built-in method for generating random BigInteger values.
            // Instead, random BigIntegers are constructed from randomly generated
            // byte arrays of the same length as the source.
            //RandomNumberGenerator rng = RandomNumberGenerator.Create();
            //byte[] bytes = new byte[source.ToByteArray().LongLength];
            //BigInteger a;

            //for (int i = 0; i < certainty; i++)
            //{
            //    do
            //    {
            //        // This may raise an exception in Mono 2.10.8 and earlier.
            //        // http://bugzilla.xamarin.com/show_bug.cgi?id=2761
            //        rng.GetBytes(bytes);
            //        a = new BigInteger(bytes);
            //    }
            //    while (a < 2 || a >= source - 2);

            //    BigInteger x = BigInteger.ModPow(a, d, source);
            //    if (x == 1 || x == source - 1)
            //        continue;

            //    for (int r = 1; r < s; r++)
            //    {
            //        x = BigInteger.ModPow(x, 2, source);
            //        if (x == 1)
            //            return false;
            //        if (x == source - 1)
            //            break;
            //    }

            //    if (x != source - 1)
            //        return false;
            //}

            return true;
        }

        public bool MillerRabinPrimalityTest(BigInteger powValue, BigInteger primeCandidate)
        {
            BigInteger randomNumber = GetRandomNumber((int)primeCandidate.GetBitLength() - 1);

            BigInteger value = BigInteger.ModPow(randomNumber, powValue, primeCandidate);

            if (value == 1 || value == primeCandidate - 1)
                return true;

            while (powValue != primeCandidate - 1)
            {
                value = BigInteger.ModPow(value, 2, primeCandidate);
                powValue = powValue * 2;

                if (value == 1)
                    return false;
                if (value == primeCandidate - 1)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Calculates the initial number d, for raising 2^d in the Miller-Rabin test.
        /// The function assumes that the input number is even. Given an odd number will the number itself be returned
        /// </summary>
        /// <param name="numbern">An odd number that is n-1, where n is the number to test for primality</param>
        /// <returns>The number d, for raising 2^d in the Miller-Rabin test</returns>
        public BigInteger CalculateInitialPowerValue(BigInteger numbern)
        {

            BigInteger result = numbern;
            while (result % 2 == 0)
            {
                result = BigInteger.Divide(result, 2);
            }
            return result;
        }

        /// <summary>
        /// Generates two random BigIntegers with desired bit size.
        /// The BigIntegers is guaranteed to be odd and use all bits.
        /// </summary>
        /// <param name="bits">Length of the BigIntegers in bits</param>
        /// <returns>A BigInteger array containing two random BigIntegers</returns>
        public BigInteger[] GetTwoRandomOddNumbers(int bits)
        {
            Random rand = new Random();
            BitArray bitArrayA = new BitArray(bits);
            BitArray bitArrayB = new BitArray(bits);

            bitArrayA[0] = true;
            bitArrayB[0] = true;


            // makes sure number is not even
            bitArrayA[bits - 1] = true;
            bitArrayB[bits - 1] = true;

            for (int i = 1; i < bits - 1; i++)
            {
                bitArrayA[i] = rand.Next(0, 2) == 0 ? false : true;
                bitArrayB[i] = rand.Next(0, 2) == 0 ? false : true;
            }

            byte[] bytesA = new byte[(bits - 1) / 8 + 1];
            byte[] bytesB = new byte[(bits - 1) / 8 + 1];

            bitArrayA.CopyTo(bytesA, 0);
            bitArrayB.CopyTo(bytesB, 0);

            return new BigInteger[] {
                BigInteger.Abs(new BigInteger(bytesA)),
                BigInteger.Abs(new BigInteger(bytesB))
            };
        }

        public BigInteger GetRandomNumber(int bits)
        {
            Random rand = new Random();
            BitArray bitArray = new BitArray(bits);

            // makes sure number is not even
            bitArray[bits - 1] = true;

            for (int i = 0; i < bits - 1; i++)
            {
                bitArray[i] = rand.Next(0, 2) == 0 ? false : true;
            }

            byte[] bytes = new byte[(bits - 1) / 8 + 1];

            bitArray.CopyTo(bytes, 0);

            return BigInteger.Abs(new BigInteger(bytes));
         
        }
    }
}

