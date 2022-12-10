using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public static class PrimeService
    {
        /// <summary>
        /// Generates two random prime numbers with desired bit length
        /// </summary>
        /// <param name="bits">The length of the numbers in bits</param>
        /// <param name="rounds">Optional parameter to modify certainty of the the numbers to be prime</param>
        /// <returns>Array of two prime numbers</returns>
        public static BigInteger[] GetTwoPrimes(int bits, int rounds = 40)
        {
            BigInteger[] randomNumbers = GetTwoRandomOddNumbers(bits);

            BigInteger prime1 = randomNumbers[0];
            while (!IsNumberPrime(prime1, rounds))
            {
                prime1 += 2;

            }

            BigInteger prime2 = randomNumbers[1];
            while (!IsNumberPrime(prime2, rounds) || prime1 == prime2)
            {
                prime2 += 2;
            }

            return new BigInteger[] { prime1, prime2 };
        }

        /// <summary>
        /// Method for testing the Prime generation algorithm. Method takes various inputs to configure tests
        /// </summary>
        /// <param name="bits">Bit size of the prime to be generated</param>
        /// <param name="rounds">How many times Miller-Rabin tests for primality</param>
        /// <param name="testAmount">How many tests to run (More tests takes longer)</param>
        /// <param name="usePreCheck">Choose whether or not to use prime pre check before Miller-Rabin algorithm</param>
        /// <param name="maxNumber">Uses sieve of Eatosthenes with given number</param>
        public static void TestPrimeAlgorithm(int bits, int rounds = 40, int testAmount = 1, bool usePreCheck = true, int maxNumber = -1)
        {
            if (testAmount < 1) testAmount = 1;

            List<long> loggedTimes = new List<long>();
            List<int> timesIncremented = new List<int>();

            Stopwatch watch = new System.Diagnostics.Stopwatch();
            for (int i = 0; i < rounds; i++)
            {
                watch.Reset();
                int j = 0;

                watch.Start();

                BigInteger randomNumber = GetTwoRandomOddNumbers(bits)[0];

                while (!IsNumberPrime(randomNumber, rounds, usePreCheck: usePreCheck, sieveOfEratosthenesNumber: maxNumber))
                {
                    randomNumber += 2;
                    j++;
                }

                watch.Stop();
                loggedTimes.Add(watch.ElapsedMilliseconds);
                timesIncremented.Add(j);
            }


            Console.WriteLine($"Prime number was found in {loggedTimes.Average()} ms");
            Console.WriteLine($"Prime number candidate incremented {timesIncremented.Average()} before prime number was found");
        }

        /// <summary>
        /// Checks if given number is a prime number
        /// </summary>
        /// <param name="primeCandidate">The number to test for primality</param>
        /// <param name="rounds">How many times to perform the test on the number</param>
        /// <param name="usePreCheck">Indicate if prime check should include precheck</param>
        /// <param name="sieveOfEratosthenesNumber">If provided, precheck uses Sieve Of Eratosthenes and finds all primes up to this number</param>
        /// <returns>False if primeCandidate is composite. True if primeCandidate is probably a prime (not 100% accuracy)</returns>
        internal static bool IsNumberPrime(BigInteger primeCandidate, int rounds, bool usePreCheck = true, int sieveOfEratosthenesNumber = -1)
        {
            if (primeCandidate == 2 || primeCandidate == 3)
                return true;
            if (primeCandidate < 2 || primeCandidate % 2 == 0)
                return false;

            int[]? listOfPrimes = null;

            if(sieveOfEratosthenesNumber > 5)
            {
                listOfPrimes = PrimeService.SieveOfEratosthenes(sieveOfEratosthenesNumber);  
            }

            if (usePreCheck && !PrimePreCheck(primeCandidate, listOfPrimes))
            {
                return false;
            }

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
        /// Checks if the prime candidate can be divided by a set of small prime numbers
        /// </summary>
        /// <param name="primeCandidate">The number to check for primality</param>
        /// <param name="listOfPrimes">List of primes to use in check</param>
        /// <returns>False if prime candidate is not a prime. True if there is a possibility it is a prime</returns>
        internal static bool PrimePreCheck(BigInteger primeCandidate, int[]? listOfPrimes = null )
        {
            if(listOfPrimes == null)
            {
                // Hundred first primes
                listOfPrimes = new int[] { 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557 };
            }

            bool couldBePrime = true;

            for (int i = 0; i < listOfPrimes.Length; i++)
            {
                if (primeCandidate == listOfPrimes[i]) break;

                if (primeCandidate % listOfPrimes[i] == 0)
                {
                    couldBePrime = false;
                    break;
                }
            }

            return couldBePrime;
        }

        /// <summary>
        /// The Miller-Rabin Primality test identifies if the given number is a composite
        /// </summary>
        /// <param name="powValue">A odd number that sitisfies powValue*2^r = primeCandidate - 1 for some r >= 1</param>
        /// <param name="primeCandidate">The number to test if composite</param>
        /// <returns>False if primeCandidate is composite. True if primeCandidate is probably a prime (not 100% accuracy)</returns>
        internal static bool MillerRabinPrimalityTest(BigInteger powValue, BigInteger primeCandidate)
        {
            BigInteger randomNumber = GetRandomNumber(primeCandidate);

            BigInteger value = BigInteger.ModPow(randomNumber, powValue, primeCandidate);

            if (value == 1 || value == primeCandidate - 1)
                return true;

            while (powValue <= primeCandidate - 1)
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
        /// <param name="number">An odd number that is n-1, where n is the number to test for primality</param>
        /// <returns>The number d, for raising 2^d in the Miller-Rabin test</returns>
        internal static BigInteger CalculateInitialPowerValue(BigInteger number)
        {
            if (number < 2)
            {
                return number;
            }
            BigInteger result = number;
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
        internal static BigInteger[] GetTwoRandomOddNumbers(int bits)
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
        internal static BigInteger GetRandomNumber(BigInteger number)
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

        /// <summary>
        /// Finds all prime numbers up to input number
        /// </summary>
        /// <param name="maxNumber">How many numbers to search for primes</param>
        /// <returns>A list of numbers up to input number</returns>
        internal static int[] SieveOfEratosthenes(int maxNumber)
        {

            bool[] isPrime = new bool[maxNumber + 1];

            for (int i = 0; i <= maxNumber; i++)
            {
                isPrime[i] = true;
            }

            for (int j = 2; j * j <= maxNumber; j++)
            {
                if (isPrime[j] == true)
                {
                    for (int i = j * j; i <= maxNumber; i += j)
                        isPrime[i] = false;
                }
            }

            int primesFound = isPrime.Where((b, i) => i > 3 && b == true).Count();

            int[] primes = new int[primesFound];
            int primesIndex = 0;

            for (int i = 5; i <= maxNumber; i++)
            {
                if (isPrime[i] == true)
                {
                    primes[primesIndex] = i;
                    primesIndex++;
                }
            }

            return primes;
        }
    }
}

