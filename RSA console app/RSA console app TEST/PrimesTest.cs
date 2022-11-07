using NUnit.Framework;
using RSA_console_app;
using System.Numerics;

namespace RSA_console_app.Tests
{
    [TestFixture]
    public class PrimesTest
    {
        private PrimeService _primes;

        [SetUp]
        public void SetUp()
        {
            _primes = new PrimeService();
        }

        [Test]
        public void GetPrimeTest()
        {
            Assert.AreEqual(_primes.GetPrime(), 17);            
        }

        [Test]
        public void GetTwoRandomOddNumbers_returns_correctSizeNumbers()
        {
            BigInteger[] arrayBig = _primes.GetTwoRandomOddNumbers(512);
            BigInteger[] arraySmall = _primes.GetTwoRandomOddNumbers(5);

            CollectionAssert.Contains(new[] { 153, 154 }, arrayBig[0].ToString().Length);
            CollectionAssert.Contains(new[] { 153, 154 }, arrayBig[1].ToString().Length);

            Assert.AreEqual(2, arraySmall[0].ToString().Length);
            Assert.AreEqual(2, arraySmall[1].ToString().Length);
        }

        [Test]
        public void GetTwoRandomOddNumbers_returns_oddNumbers()
        {
            BigInteger[] array = _primes.GetTwoRandomOddNumbers(512);
            BigInteger one = new BigInteger(1);

            Assert.AreEqual(one, array[0] % 2);
            Assert.AreEqual(one, array[1] % 2);
        }
    }
}
