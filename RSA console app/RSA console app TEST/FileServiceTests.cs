using NUnit.Framework;
using NUnit.Framework.Constraints;
using RSA_console_app.models;
using RSA_console_app.services;
using System.IO;
using System.Numerics;

namespace RSA_console_app.Tests
{
    [TestFixture]
    public class FileServiceTests
    {
        private PublicKey _publicKey;
        private PrivateKey _privateKey;

        [SetUp]
        public void SetUp()
        {
            _publicKey = new PublicKey(new BigInteger(5021), new BigInteger(2), new BigInteger(-1));
            _privateKey = new PrivateKey(new BigInteger(16418641), new BigInteger(1684651));
        }

        [Test]
        public void WritePublicKey_canWritePublicKeyToFileWithoutPath()
        {
            FileService.WritePublicKey(_publicKey);

            Assert.True(File.Exists("key.pub"));

            if (File.Exists("key.pub"))
            {
                File.Delete("key.pub");
            }
        }

        [Test]
        public void WritePublicKey_canWritePublicKeyToFileWithPath()
        {
            string path = Path.GetTempPath();
            FileService.WritePublicKey(_publicKey, path);

            Assert.True(File.Exists($"{path}/key.pub"));

            if (File.Exists($"{path}/key.pub"))
            {
                File.Delete($"{path}/key.pub");
            }
        }

        [Test]
        public void WritePublicKey_writeToNonExistingPathFails()
        {
            string path = ".test";
            
            Assert.Throws<Exception>(() => FileService.WritePublicKey(_publicKey, path));

            if (File.Exists($"{path}/key.pub"))
            {
                File.Delete($"{path}/key.pub");
            }
        }

        [Test]
        public void ReadPublicKey_canReadFile()
        {
            FileService.WritePublicKey(_publicKey);

            PublicKey publicKey = FileService.ReadPublicKey();

            Assert.AreEqual(publicKey.n, _publicKey.n);
            Assert.AreEqual(publicKey.e, _publicKey.e);

            if (File.Exists("key.pub"))
            {
                File.Delete("key.pub");
            }
        }

        [Test]
        public void ReadPublicKey_canNotReadFileIfFileIsCorrupted()
        {
            FileService.WritePublicKey(_publicKey);

            string[] lines = File.ReadAllLines("key.pub");

            lines[0] = "---MalFunc---";

            File.WriteAllLines("key.pub", lines);

            Assert.Throws<Exception>(() => FileService.ReadPublicKey());

            if (File.Exists("key.pub"))
            {
                File.Delete("key.pub");
            }
        }

        [Test]
        public void WritePrivateKey_canWritePublicKeyToFileWithoutPath()
        {
            FileService.WritePrivateKey(_privateKey);

            Assert.True(File.Exists("key.priv"));

            if (File.Exists("key.priv"))
            {
                File.Delete("key.priv");
            }
        }

        [Test]
        public void WritePrivateKey_canWritePublicKeyToFileWithPath()
        {
            string path = Path.GetTempPath();
            FileService.WritePrivateKey(_privateKey, path);

            Assert.True(File.Exists($"{path}/key.priv"));

            if (File.Exists($"{path}/key.priv"))
            {
                File.Delete($"{path}/key.priv");
            }
        }

        [Test]
        public void WritePrivateKey_writeToNonExistingPathFails()
        {
            string path = ".test";

            Assert.Throws<Exception>(() => FileService.WritePrivateKey(_privateKey, path));

            if (File.Exists($"{path}/key.priv"))
            {
                File.Delete($"{path}/key.priv");
            }
        }

        [Test]
        public void ReadPrivateKey_canReadFile()
        {
            FileService.WritePrivateKey(_privateKey);

            PrivateKey privateKey = FileService.ReadPrivateKey();

            Assert.AreEqual(privateKey.n, _privateKey.n);
            Assert.AreEqual(privateKey.d, _privateKey.d);

            if (File.Exists("key.priv"))
            {
                File.Delete("key.priv");
            }
        }

        [Test]
        public void ReadPrivateKey_canNotReadFileIfFileIsCorrupted()
        {
            FileService.WritePrivateKey(_privateKey);

            string[] lines = File.ReadAllLines("key.priv");

            lines[0] = "---MalFunc---";

            File.WriteAllLines("key.priv", lines);

            Assert.Throws<Exception>(() => FileService.ReadPrivateKey());

            if (File.Exists("key.priv"))
            {
                File.Delete("key.priv");
            }
        }

        [Test]
        public void MessageCanBeWrittenAndRead()
        {
            string message = "Hello world";

            FileService.WriteMessage(message, "");

            string output = FileService.ReadMessage("message.txt");

            Assert.AreEqual(message, output);

            if (File.Exists("message.txt"))
            {
                File.Delete("message.txt");
            }
        }
    }
}
