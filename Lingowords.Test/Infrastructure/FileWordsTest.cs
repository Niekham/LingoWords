
using NUnit.Framework;

namespace Lingowords.Test.Infrastructure
{
    class FileWordsTest
    {
        private IWordsFile _file;


        [SetUp]
        public void Setup()
        {
            _file = new FileWords();
        }

        [TestCase("DUTCH", true)]
        [TestCase("DUTCH_COMMON", true)]
        [TestCase("glorbjech", false)]
        public void Exists(string language, bool expected)
        {
            bool actual = _file.Exists(language);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("DUTCH", true)]
        [TestCase("DUTCH_COMMON", true)]
        [TestCase("glorbjech", false)]
        public void Read(string key, bool expected)
        {
            string[] result = _file.Read(key);

            bool actual = result.Length > 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
