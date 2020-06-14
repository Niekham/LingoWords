using System;
using System.Collections.Generic;
using System.Text;
using Lingowords;
using NUnit.Framework;
using Moq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Localization.Internal;

namespace Lingowords.Test.Application
{
    class WordProcessorTest
    {
        private IProcessor _processor;
        private Words _words;
        private string[] _wordList;
        private Mock _file;
        private Mock _memory;

        [SetUp]
        public void Setup()
        {
            _wordList = new string[] { "woord", "koord", "gehoor", "prakken", "geranem", "haarbal", "waanzin" };
            _words = new Words(
                    _wordList,
                    Language.DUTCH
                );

            _file = new Mock<IWordsFile>();

            _memory = new Mock<IWordsMemory>();

            _processor = new WordProcessor(_file.As<IWordsFile>().Object, _memory.As<IWordsMemory>().Object);
        }

        [TestCase("DUTCH", false)]
        [TestCase("DUTCH_COMMON", true)]
        public void ListWords_NotInMemory(string key, bool common)
        {
            _memory.As<IWordsMemory>().Setup(x => x.Exists(key)).Returns(false);
            _memory.As<IWordsMemory>().Setup(x => x.Read(key)).Returns(_words);
            _memory.As<IWordsMemory>().Setup(x => x.Save(key, _words));

            _file.As<IWordsFile>().Setup(x => x.Read(key)).Returns(_wordList);
;
          
            _processor.ListWords( "NOTEXISTINGLANGUAGE", common );


            _memory.As<IWordsMemory>().Verify(x => x.Read(It.IsAny<string>()), Times.Never());
            _memory.As<IWordsMemory>().Verify(x => x.Save(It.IsAny<string>(), It.IsAny<Words>()), Times.Once());
            _file.As<IWordsFile>().Verify(x => x.Read(It.IsAny<string>()), Times.Once());
        }

        [TestCase("DUTCH", false)]
        [TestCase("DUTCH_COMMON", true)]
        public void ListWords_InMemory(string key, bool common)
        {
            _memory.As<IWordsMemory>().Setup(x => x.Exists(key)).Returns(true);
            _memory.As<IWordsMemory>().Setup(x => x.Read(key)).Returns(_words);
            ;

            _processor.ListWords(key, common);


            _memory.As<IWordsMemory>().Verify(x => x.Exists(It.IsAny<string>()), Times.Once());
            _memory.As<IWordsMemory>().Verify(x => x.Read(It.IsAny<string>()), Times.Once());
        }
    }
}
