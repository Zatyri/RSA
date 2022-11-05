using System;

namespace RSA_console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeService primeService = new PrimeService();
            Console.WriteLine("Here is a prime: " + primeService.GetPrime());
        }
    }
}