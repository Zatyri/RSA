using NUnit.Framework;
using RSA_console_app.services;
using System.Numerics;

namespace RSA_console_app.Tests
{
    [TestFixture]
    public class PrimesTest
    {

        [Test]
        public void GetTwoRandomOddNumbers_returns_correctSizeNumbers()
        {
            int[] testValues = new int[] {1,3,7,8,100,200,256,500,511,512,};

            for(int i = 0; i < testValues.Length; i++)
            {
                int testValue = testValues[i];

                BigInteger[] testArr = PrimeService.GetTwoRandomOddNumbers(testValue);
                Assert.AreEqual(testValue, testArr[0].GetBitLength());
                Assert.AreEqual(testValue, testArr[1].GetBitLength());
            }
        }

        [Test]
        public void GetTwoRandomOddNumbers_returns_oddNumbers()
        {
            int[] testValues = new int[] { 1, 3, 7, 8, 100, 200, 256, 500, 511, 512, };
            BigInteger one = new BigInteger(1);

            for (int i = 0; i < testValues.Length; i++)
            {
                int testValue = testValues[i];

                BigInteger[] array = PrimeService.GetTwoRandomOddNumbers(testValue);
                Assert.AreEqual(one, array[0] % 2);
                Assert.AreEqual(one, array[1] % 2);
            }
        }

        [Test]
        public void GetRandomNumber_returns_number()
        {
            BigInteger Big = PrimeService.GetRandomNumber(BigInteger.Parse("6560522779398978078428968808830616817527644566298800171483191999296788812867182494507522684947796326950279426930276927952705588425163193716055887444396863"));
            BigInteger Small = PrimeService.GetRandomNumber(5);

            Assert.AreEqual(Big.GetType(), typeof(BigInteger));

            Assert.AreEqual(Small.GetType(), typeof(BigInteger));
        }

        [Test]
        public void CalculateInitialPowerValue_returns_correctValue()
        {
            BigInteger value1 = PrimeService.CalculateInitialPowerValue(52);
            BigInteger value2 = PrimeService.CalculateInitialPowerValue(12345678900);

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
                BigInteger.Parse("4643186763143414577397734131"),
                BigInteger.Parse("16546841613468464131541654"),
                BigInteger.Parse("4"),
                BigInteger.Parse("50"),
                BigInteger.Parse("1264135146874897"),
                BigInteger.Parse("465468798798798413213744343864165734798131789"),
                BigInteger.Parse("46879843576352354788943483578956465178413686876135867684135674864135657864131569776131899798745613214789"),
            } ;
            foreach(BigInteger composite in composites)
            {
                BigInteger pow = PrimeService.CalculateInitialPowerValue(composite - 1);
                bool answer = PrimeService.MillerRabinPrimalityTest(pow, composite);
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
                BigInteger.Parse("33406332761218604879634747981633932576882832606499652474255260948901623997540957483980713603393601960366379716626506344582840199795044706962460920267758971"),
                BigInteger.Parse("17341"),
                BigInteger.Parse("5419"),
                BigInteger.Parse("993509982948192318572490801520376985115072026870249049049585019386806208628743382726021227"),
                BigInteger.Parse("211119830027677769113700446016736160902091151145063544525331364345974801323468169216501239"),
                BigInteger.Parse("78403396574377717039961873130305003646480764588398365766305633907706073734186054589816841538946221074713961704217883540564916793981390352392865344267867808101945528502829325188077425493131790596306241"),
                BigInteger.Parse("895358684789216204912022750510508351929317514547472202484358218440711975306316286767346704789750670622563337177001338921041733917710376163808591416571194175886400118058215322217134434037967633570769225965321290059318249938723781143581443340605447549294718389195892079981756248001580042910899288048463"),
                BigInteger.Parse("3026664782872926417223465322068015747770243105435778457025544920020350962708901926351486367921371104301219452926986406366981672167974932090685600374445826156962480260273362844399197321160061574531912490839377011234302391870290315204129116940499468791273973")

            };
            foreach (BigInteger prime in primes)
            {
                BigInteger pow = PrimeService.CalculateInitialPowerValue(prime - 1);
                bool answer = PrimeService.MillerRabinPrimalityTest(pow, prime);
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
                bool answer = PrimeService.IsNumberPrime(composite, 40);
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
                bool answer = PrimeService.IsNumberPrime(prime, 40);
                Assert.IsTrue(answer);
            }
        }

        [Test]
        public void GetTwoPrimes_returns_TwoNumbers()
        {
            BigInteger[] primes = PrimeService.GetTwoPrimes(50);

            string prime1 = primes[0].ToString();
            string prime2 = primes[1].ToString();

            Assert.AreEqual(2, primes.Length);
        }

        [Test]
        public void TestPrimeAlgorithm_DoesNotThrow()
        {
            PrimeService.TestPrimeAlgorithm(512, 5, 2, true);
            Assert.DoesNotThrow(() => PrimeService.TestPrimeAlgorithm(1024, 5, 2, true));
        }

        [Test]
        public void SieveOfEratosthenes_returns_hundredFirstPrimes()
        {
            int[] primes = PrimeService.SieveOfEratosthenes(557); 
            int[] hundredFirstPrimes = new int[] { 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557 };

            Assert.AreEqual(primes, hundredFirstPrimes);
        }
    }
}
