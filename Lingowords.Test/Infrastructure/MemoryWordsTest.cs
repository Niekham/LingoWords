using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;

namespace Lingowords.Test.Infrastructure
{
    class MemoryWordsTest
    {
        private IWordsMemory _memoryWords;
        private Mock _cache;
        private Words _words;

        [SetUp]
        public void SetUp()
        {
            _cache = new Mock<IMemoryCache>();
            _memoryWords = new MemoryWords( _cache.As<IMemoryCache>().Object );
            _words = new Words( new string[] { "woord", "koord", "schroot", "vloot", "prutser" }, Language.DUTCH );
        }

        [Test]
        public void Read_TryGetIsFalse()
        {
            object value;
            _cache.As<IMemoryCache>().Setup(x => x.TryGetValue(It.IsAny<object>(), out value )).Returns(false);

            var words = _memoryWords.Read(Language.DUTCH.ToString());

            Assert.IsTrue(words == null);
        }

        [Test]
        public void Read_TryGetIstrue()
        {
            object value = _words;
            _cache.As<IMemoryCache>().Setup(x => x.TryGetValue("DUTCH", out value)).Returns(true);

            var words = _memoryWords.Read(Language.DUTCH.ToString());
            Assert.AreEqual(words, _words);
        }

        [TestCase(false, "DUTCH")]
        [TestCase(false, "FLORBS")]
        [TestCase(true, "DUTCH")]
        public void Exists(bool exists, string language)
        {
            object value = exists ? _words : null;

            _cache.As<IMemoryCache>().Setup(x => x.TryGetValue(language, out value)).Returns(exists);
            var result = _memoryWords.Exists( language );

            Assert.AreEqual( result, exists );
        }

        [Test]
        public void Remove()
        {
            _cache.As<IMemoryCache>().Setup(x => x.Remove("DUTCH"));

            _memoryWords.Remove("DUTCH");

            _cache.As<IMemoryCache>().Verify(x => x.Remove(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Save()
        {
            _cache.As<IMemoryCache>().Setup(x => x.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>());

            _memoryWords.Save("DUTCH", _words);

            _cache.As<IMemoryCache>().Verify(x => x.CreateEntry(It.IsAny<object>()), Times.Once());
        }

    }
}
