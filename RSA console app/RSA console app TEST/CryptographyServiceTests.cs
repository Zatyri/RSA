using NUnit.Framework;
using RSA_console_app.models;
using RSA_console_app.services;
using System.Numerics;
using System.Text;

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
            _keyGenerator = new KeyGeneration();
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

        [Test]
        public void SameMessageEncryptedTwiceAreNotEqual()
        {
            string message = "Encrypt me";

            string encryptedMessageOne = CryptographyService.EncryptMessage(message, _publicKey);

            string encryptedMessageTwo = CryptographyService.EncryptMessage(message, _publicKey);

            Assert.AreNotEqual(encryptedMessageOne, encryptedMessageTwo);
        }

        [Test]
        public void AddPKSCPadding_returns_paddedMessageWithLengthN()
        {
            byte[] message = Encoding.ASCII.GetBytes("Hello world");
            byte[] paddedMessage = CryptographyService.AddPKSCPadding(message, 128);
            Assert.AreEqual(paddedMessage.Length, 125);
        }

        [Test]
        public void AddPKSCPadding_throws_ifMessageLongerThanNPlusMinPadding()
        {
            byte[] message = Encoding.ASCII.GetBytes("Hello world");
            Assert.Throws<Exception>(() => CryptographyService.AddPKSCPadding(message, 20));
        }

        [Test]
        public void RemovePKSCPadding_returns_originalMessage()
        {
            byte[] message = Encoding.ASCII.GetBytes("Hello world");
            byte[] paddedMessage = CryptographyService.AddPKSCPadding(message, 128);
            byte[] paddingRemoved = CryptographyService.RemovePKSCPadding(paddedMessage);

            Assert.AreEqual(message, paddingRemoved);
        }

        [Test]
        public void RemovePKSCPadding_throws_ifMessageNotProperlyPadded()
        {
            byte[] message = Encoding.ASCII.GetBytes("Hello world");
            byte[] paddedMessage = CryptographyService.AddPKSCPadding(message, 128);
            paddedMessage[1] = 0x03;
            Assert.Throws<Exception>(() => CryptographyService.RemovePKSCPadding(paddedMessage));
        }
    }
}