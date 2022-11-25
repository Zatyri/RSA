using NUnit.Framework;
using RSA_console_app.models;
using RSA_console_app.services;
using System.Numerics;

namespace RSA_console_app.Tests
{
    [TestFixture]
    public class CryptographyServiceTests
    {
        private PublicKey _publicKey;

        [SetUp]
        public void SetUp()
        {
            _publicKey = new KeyGeneration(new PrimeService()).GeneratePublicKey(1024);
        }

        [Test]
        public void EncryptMessage_returns_string()
        {
            string message = "Encrypt me";

            string encryptedMessage = CryptographyService.EncryptMessage(message, _publicKey);

            Assert.AreEqual(typeof(string), encryptedMessage.GetType());
        }
    }
}