using Lingowords;
using NUnit.Framework;

namespace LingoWords.Test
{
    public class WordsTest
    {
        private Words _words;
        private Language _language;
        private string[] _listOfWords;

        [SetUp]
        public void Setup()
        {
            _language = Language.DUTCH;
            _listOfWords = new string[] { "23okeg", ".brokko", "time-elapsed", "woord", "lengte", "hoogte", "zwijgen", "kruis", "gruis", "Greta", "huis", "weerzien" };
            _words = new Words(_listOfWords, _language);
        }

        [TestCase("23okeg")]
        [TestCase(".brokko")]
        [TestCase("time-elapsed")]
        [TestCase("Hans")]
        [TestCase("Greta")]
        [TestCase("huis")]
        [TestCase("weerzien")]
        public void WordsShouldNotContain(string wrongWord)
        {
            var words = _words.WordsList();

            Assert.IsFalse(words.Contains(wrongWord), $"Should't contain {wrongWord}");
        }

        [Test]
        public void ReturnLanguageAsString()
        {
            var result = _words.Language();

            Assert.IsTrue(result == _language.ToString());
        }
    }
}