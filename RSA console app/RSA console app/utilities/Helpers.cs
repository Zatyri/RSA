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
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BigInteger gcd(BigInteger a, BigInteger b)
        {
            BigInteger temp;
            while (true)
            {
                temp = a % b;
                if (temp == 0)
                {
                    return b;
                }
                a = b;
                b = temp;
            }
        }
    }
}
