using System.Numerics;

namespace RSA_console_app
{
    /// <summary>
    /// Helper file with helpful functions
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Calculates greatest common divisor
        /// </summary>
        /// <param name="numberOne">Number one</param>
        /// <param name="numberTwo">Number two</param>
        /// <returns>The greatest common divisor of the two given numbers</returns>
        public static BigInteger GreatestCommonDivisor(BigInteger numberOne, BigInteger numberTwo)
        {
            BigInteger temp;
            while (true)
            {
                temp = numberOne % numberTwo;
                if (temp == 0)
                {
                    return numberTwo;
                }
                numberOne = numberTwo;
                numberTwo = temp;
            }
        }
    }
}
