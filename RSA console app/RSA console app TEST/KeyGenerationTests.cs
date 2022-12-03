using NUnit.Framework;
using RSA_console_app.models;
using RSA_console_app.services;
using System.Numerics;

namespace RSA_console_app.Tests
{
    [TestFixture]
    public class KeyGenerationTests
    {
        private KeyGeneration _keyGenerator;        

        [SetUp]
        public void SetUp()
        {
            _keyGenerator = new KeyGeneration();
        }
        [Test]
        public void GeneratePublicKey_returns_publicKeyObject()
        {
            PublicKey publicKey =  _keyGenerator.GeneratePublicKey(512);

            Assert.IsInstanceOf(typeof(PublicKey), publicKey);
        }

        [Test]
        public void GeneratePublicKey_returns_publicKeyOfDesiredSize()
        {
            PublicKey publicKey1 = _keyGenerator.GeneratePublicKey(512);
            PublicKey publicKey2 = _keyGenerator.GeneratePublicKey(1024);
            PublicKey publicKey3 = _keyGenerator.GeneratePublicKey(9);

            Assert.GreaterOrEqual(publicKey1.n.GetBitLength(), 511);
            Assert.GreaterOrEqual(publicKey2.n.GetBitLength(), 1023);
            Assert.GreaterOrEqual(publicKey3.n.GetBitLength(), 8);
        }

        [Test]
        public void GeneratePrivateKey_returns_privateKeyObject()
        {
            
            PrivateKey privateKey = _keyGenerator.GeneratePrivateKey(_keyGenerator.GeneratePublicKey(512));

            Assert.IsInstanceOf(typeof(PrivateKey), privateKey);
        }

        [Test]
        public void GeneratePrivateKey_returns_privateKeyWithAlostSameBitSizeAsPublicKey()
        {
            PrivateKey privateKey1 = _keyGenerator.GeneratePrivateKey(_keyGenerator.GeneratePublicKey(512));
            PrivateKey privateKey2 = _keyGenerator.GeneratePrivateKey(_keyGenerator.GeneratePublicKey(1023));
            PrivateKey privateKey3 = _keyGenerator.GeneratePrivateKey(_keyGenerator.GeneratePublicKey(15));

            Assert.GreaterOrEqual(privateKey1.d.GetBitLength(), 500);
            Assert.GreaterOrEqual(privateKey2.d.GetBitLength(), 1000);
            Assert.GreaterOrEqual(privateKey3.d.GetBitLength(), 10);

        }
    }
}
