using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_console_app
{
    public static class Helpers
    {
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
