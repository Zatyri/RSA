using NUnit.Framework;
using RSA_console_app.services;
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
        public void GetTwoRandomOddNumbers_returns_correctSizeNumbers()
        {
            BigInteger[] arrayBig = _primes.GetTwoRandomOddNumbers(512);
            BigInteger[] arraySmall = _primes.GetTwoRandomOddNumbers(5);

            CollectionAssert.Contains(new[] { 153, 154, 155 }, arrayBig[0].ToString().Length);
            CollectionAssert.Contains(new[] { 153, 154, 155 }, arrayBig[1].ToString().Length);

            Assert.AreEqual(3, arraySmall[0].ToString().Length);
            Assert.AreEqual(3, arraySmall[1].ToString().Length);
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
        public void GetRandomNumber_returns_correctSizeNumber()
        {
            BigInteger Big = _primes.GetRandomNumber(BigInteger.Parse("6560522779398978078428968808830616817527644566298800171483191999296788812867182494507522684947796326950279426930276927952705588425163193716055887444396863"));
            BigInteger Small = _primes.GetRandomNumber(5);

            CollectionAssert.Contains(new[] { 153, 154, 155 }, Big.ToString().Length);

            CollectionAssert.Contains(new[] { 1,2 }, Small.ToString().Length);
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
            BigInteger[] composites = new BigInteger[]
            {
                BigInteger.Parse("6560522779398978078428968808830616817527644566298800171483191999296788812867182494507522684947796326950279426930276927952705588425163193716055887444396863"), 
                BigInteger.Parse("100"),
                BigInteger.Parse("104"),
                BigInteger.Parse("6560522779398978078428968808830616817527644566298800171483191999296788812867182494507522684947796326950279426930246423186776927952705588425163193716055887444396863"),
                BigInteger.Parse("4643186763143414577397734131")
            } ;
            foreach(BigInteger composite in composites)
            {
                BigInteger pow = _primes.CalculateInitialPowerValue(composite - 1);
                bool answer = _primes.MillerRabinPrimalityTest(pow, composite);
                Assert.IsFalse(answer);
            }
        }


        [Test]
        public void MillerRabinTest_returns_trueOnPrime()
        {
            BigInteger[] primes = new BigInteger[]
            {
                BigInteger.Parse("7"),
                BigInteger.Parse("307"),
                BigInteger.Parse("1548604627"),
                BigInteger.Parse("9695397363629165914986971"),
                BigInteger.Parse("33406332761218604879634747981633932576882832606499652474255260948901623997540957483980713603393601960366379716626506344582840199795044706962460920267758971")
            };
            foreach (BigInteger prime in primes)
            {
                BigInteger pow = _primes.CalculateInitialPowerValue(prime - 1);
                bool answer = _primes.MillerRabinPrimalityTest(pow, prime);
                Assert.IsTrue(answer);
            }
        }

        [Test]
        public void IsNumberPrime_returns_falseOnComposite()
        {
            BigInteger[] composites = new BigInteger[]
            {
                BigInteger.Parse("6560522779398978078428968808830616817527644566298800171483191999296788812867182494507522684947796326950279426930276927952705588425163193716055887444396863"),
                BigInteger.Parse("100"),
                BigInteger.Parse("104"),
                BigInteger.Parse("6560522779398978078428968808830616817527644566298800171483191999296788812867182494507522684947796326950279426930246423186776927952705588425163193716055887444396863"),
                BigInteger.Parse("4643186763143414577397734131")
            };
            foreach (BigInteger composite in composites)
            {
                bool answer = _primes.IsNumberPrime(composite, 40);
                Assert.IsFalse(answer);
            }
        }


        [Test]
        public void IsNumberPrime_returns_trueOnPrime()
        {
            BigInteger[] primes = new BigInteger[]
            {
                BigInteger.Parse("7"),
                BigInteger.Parse("307"),
                BigInteger.Parse("1548604627"),
                BigInteger.Parse("9695397363629165914986971"),
                BigInteger.Parse("33406332761218604879634747981633932576882832606499652474255260948901623997540957483980713603393601960366379716626506344582840199795044706962460920267758971")
            };
            foreach (BigInteger prime in primes)
            {
                bool answer = _primes.IsNumberPrime(prime, 40);
                Assert.IsTrue(answer);
            }
        }

        [Test]
        public void GetTwoPrimes_returns_TwoNumbers()
        {
            BigInteger[] primes = _primes.GetTwoPrimes(50);

            string prime1 = primes[0].ToString();
            string prime2 = primes[1].ToString();

            Assert.AreEqual(2, primes.Length);
        }
    }
}
