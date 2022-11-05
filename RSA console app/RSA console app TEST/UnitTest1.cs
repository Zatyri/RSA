using NUnit.Framework;
using RSA_console_app;

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
    }
}
