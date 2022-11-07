using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        /// <summary>
        /// Generates two random BigIntegers with desired bit size.
        /// The BigIntegers is guaranteed to use all bits and be odd.
        /// </summary>
        /// <param name="bits">Length of the BigIntegers in bits</param>
        /// <returns>A BigInteger array containing two random BigIntegers</returns>
        public BigInteger[] GetTwoRandomOddNumbers(int bits)
        {
            Random rand = new Random();
            BitArray bitArrayA = new BitArray(bits);
            BitArray bitArrayB = new BitArray(bits);

            // makes sure number is as large as the required bits
            bitArrayA[0] = true; 
            bitArrayB[0] = true;

            // makes sure number is not even
            bitArrayA[bits - 1] = true;
            bitArrayB[bits - 1] = true;

            for (int i = 1; i < bits - 1; i++)
            {
                bitArrayA[i] = rand.Next(0,2) == 0 ? false : true;
                bitArrayB[i] = rand.Next(0,2) == 0 ? false : true;
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
    }
}
