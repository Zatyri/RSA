using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app.services
{
    /// <summary>
    /// Service for generating prime numbers
    /// </summary>
    public class PrimeService
    {
        /// <summary>
        /// Generates two random prime numbers with desired bit length
        /// </summary>
        /// <param name="bits">The length of the numbers in bits</param>
        /// <param name="rounds">Optional parameter to modify certainty of the the numbers to be prime</param>
        /// <returns>Array of two prime numbers</returns>
        public BigInteger[] GetTwoPrimes(int bits, int rounds = 40)
        {
            BigInteger[] randomNumbers = GetTwoRandomOddNumbers(bits);

            BigInteger prime1 = randomNumbers[0];
            while (!IsNumberPrime(prime1, rounds))
            {
                prime1 += 2;
            }

            BigInteger prime2 = randomNumbers[1];
            while (!IsNumberPrime(prime2, rounds))
            {
                prime2 += 2;
            }

            return new BigInteger[] { prime1, prime2 };
        }

        /// <summary>
        /// Checks if given number is a prime number
        /// </summary>
        /// <param name="primeCandidate">The number to test for primality</param>
        /// <param name="rounds">How many times to perform the test on the number</param>
        /// <returns>False if primeCandidate is composite. True if primeCandidate is probably a prime (not 100% accuracy)</returns>
        internal bool IsNumberPrime(BigInteger primeCandidate, int rounds)
        {
            if (primeCandidate == 2 || primeCandidate == 3)
                return true;
            if (primeCandidate < 2 || primeCandidate % 2 == 0)
                return false;

            BigInteger powValue = CalculateInitialPowerValue(primeCandidate - 1);

            for (int i = 0; i < rounds; i++)
            {
                bool isComposite = MillerRabinPrimalityTest(powValue, primeCandidate);

                if (!isComposite)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The Miller-Rabin Primality test identifies if the given number is a composite
        /// </summary>
        /// <param name="powValue">A odd number that sitisfies powValue*2^r = primeCandidate - 1 for some r >= 1</param>
        /// <param name="primeCandidate">The number to test if composite</param>
        /// <returns>False if primeCandidate is composite. True if primeCandidate is probably a prime (not 100% accuracy)</returns>
        internal bool MillerRabinPrimalityTest(BigInteger powValue, BigInteger primeCandidate)
        {
            BigInteger randomNumber = GetRandomNumber(primeCandidate);

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
        internal BigInteger CalculateInitialPowerValue(BigInteger numbern)
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
        internal BigInteger[] GetTwoRandomOddNumbers(int bits)
        {
            int offset = (bits % 8);
            if (offset != 0) offset = 8 - offset;
            int bitLength = bits + offset;

            Random rand = new Random();
            BitArray bitArrayA = new BitArray(bitLength);
            BitArray bitArrayB = new BitArray(bitLength);

            bitArrayA[0] = true;
            bitArrayB[0] = true;


            for (int i = 1; i < bitLength - offset - 1; i++)
            {
                bitArrayA[i] = rand.Next(0, 2) == 0 ? false : true;
                bitArrayB[i] = rand.Next(0, 2) == 0 ? false : true;
            }


            bitArrayA[bitLength - offset - 1] = true;
            bitArrayB[bitLength - offset - 1] = true;


            byte[] bytesA = new byte[bitLength / 8];
            byte[] bytesB = new byte[bitLength / 8];


            bitArrayA.CopyTo(bytesA, 0);
            bitArrayB.CopyTo(bytesB, 0);

            BigInteger[] result = new BigInteger[] {
                new BigInteger(bytesA, isUnsigned: true, isBigEndian: false),
                new BigInteger(bytesB, isUnsigned: true, isBigEndian: false)
            };

            if (result[0].IsEven) result[0]++;
            if (result[1].IsEven) result[1]++;

            return result;
        }

        /// <summary>
        /// Generates a random BigInteger between 2 and the input number - 1.
        /// </summary>
        /// <param name="number">Max size - 1 of the number to return</param>
        /// <returns>A random BigInteger</returns>
        internal BigInteger GetRandomNumber(BigInteger number)
        {
            int offset = 0;
            int bitLength = (int)(number - 1).GetBitLength();

            while (bitLength % 8 != 0)
            {
                offset++;
                bitLength++;
            }
            Random rand = new Random();



            BitArray bitArray = new BitArray(bitLength);

            for (int i = 1; i < bitLength - offset - 1; i++)
            {
                bitArray[i] = rand.Next(0, 2) == 0 ? false : true;
            }

            byte[] bytes = new byte[bitLength / 8];

            bitArray.CopyTo(bytes, 0);

            BigInteger result = new BigInteger(bytes, isUnsigned: true, isBigEndian: true);

            if (result < 2) result = 2;

            return result;

        }
    }
}

