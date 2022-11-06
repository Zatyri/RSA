using System;
using System.Numerics;
using System.Text;
using System.Text.Unicode;
using System.Transactions;

namespace RSA_console_app
{
    class Program
    {
        public static BigInteger gcd(BigInteger a, BigInteger b)
        {
            BigInteger temp;
            while (true)
            {
                temp = a % b;
                if(temp == 0)
                {
                    return b;
                }
                a = b;
                b = temp;
            }
        }
        static void Main(string[] args)
        {
            var prime1 = BigInteger.Parse("10239257434187668838850774989628743524235332501529058304590828737633177917022719846990467091853537717509179690463124264713626955698187302366704861740273279");
            var prime2 = BigInteger.Parse("38041570839016365879712966112072475716320228506270763556968051681235067566905668796670999976808328230409520041962659155173992004363405608234793878120307729");

            var n = prime1 * prime2;

            var e = 65537;
            var phi = (prime1 - 1) * (prime2 - 1);

            while (e < phi)
            {
                if (gcd(e, phi) == 1)
                {
                    break;
                }
                else
                {
                    e++;
                }
            }

            BigInteger d = 0;
            for (BigInteger i = 0;  ; i++)
            {
                BigInteger a;
                var times = (phi * i) + 1;
                var b = BigInteger.DivRem(times, e, out a);
                if(a == 0)
                {
                    d = b;
                    break;
                }

            }

            string message = "Hello World! åäö";

            byte[] plaintext = ASCIIEncoding.UTF8.GetBytes(message);
            BigInteger pt = new BigInteger(plaintext);
            if (pt > n)
                throw new Exception();
            Console.WriteLine("before:  " + pt);

            BigInteger ct = BigInteger.ModPow(pt, e, n);
            //Console.WriteLine("Encoded:  " + ct);
            Console.WriteLine(ASCIIEncoding.UTF8.GetString(ct.ToByteArray()));

            BigInteger dc = BigInteger.ModPow(ct, d, n);
            Console.WriteLine("Decoded:  " + dc);
            
            string decoded = ASCIIEncoding.UTF8.GetString(dc.ToByteArray());
            Console.WriteLine("As ASCII: " + decoded);

        }

        
    }
}