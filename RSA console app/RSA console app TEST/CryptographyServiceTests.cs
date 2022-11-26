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
        private PrivateKey _privateKey;
        private KeyGeneration _keyGenerator;

        [SetUp]
        public void SetUp()
        {
            _keyGenerator = new KeyGeneration(new PrimeService());
            _publicKey = _keyGenerator.GeneratePublicKey(1024);
            _privateKey = _keyGenerator.GeneratePrivateKey(_publicKey);
        }

        [Test]
        public void EncryptMessage_returns_string()
        {
            string message = "Encrypt me";

            string encryptedMessage = CryptographyService.EncryptMessage(message, _publicKey);

            Assert.AreEqual(typeof(string), encryptedMessage.GetType());
        }

        [Test]
        public void DecryptMessage_returns_string()
        {
            string encryptedMessage = "bWVzc2FnZQ==";

            string decryptedMessage = CryptographyService.DecryptMessage(encryptedMessage, _privateKey);

            Assert.AreEqual(typeof(string), encryptedMessage.GetType());
        }

        [Test]
        public void DecryptMessage_returns_orginalMessage()
        {
            string message = "Encrypt me";

            string encryptedMessage = CryptographyService.EncryptMessage(message, _publicKey);

            string decryptedMessage = CryptographyService.DecryptMessage(encryptedMessage, _privateKey);

            Assert.AreEqual(decryptedMessage, message);
        }

        [Test]
        public void EncryptMessage_throws_ifMessageTooLongForGivenKey()
        {
            string message = "Encrypt me";


            Assert.Throws<Exception>(() => CryptographyService.EncryptMessage(message, _keyGenerator.GeneratePublicKey(64)));
        }
    }
}