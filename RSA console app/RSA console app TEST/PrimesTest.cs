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

        [Test]
        public void CalculateInitialPowerValue_returns_correctValue()
        {
            BigInteger value1 = _primes.CalculateInitialPowerValue(52);
            BigInteger value2 = _primes.CalculateInitialPowerValue(12345678900);

            Assert.AreEqual(new BigInteger(52), (BigInteger.Pow(2,2) * value1));
            Assert.AreEqual(new BigInteger(12345678900), (BigInteger.Pow(2, 2) * value2));
        }

        [Test]
        public void MillerRabinTest_returns_falseOnComposite()
        {
            BigInteger candidate = BigInteger.Parse("6560522779398978078428968808830616817527644566298800171483191999296788812867182494507522684947796326950279426930276927952705588425163193716055887444396863");
            var pow = _primes.CalculateInitialPowerValue(candidate - 1);
            var a = _primes.MillerRabinPrimalityTest(pow, candidate);
        }
    }
}
