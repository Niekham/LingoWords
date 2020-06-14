using System.Linq;
using System;

namespace Lingowords
{
    /**
     * Facade
     */ 
    public class WordProcessor : IProcessor
    {
        private IWordsFile _file;
        private IWordsMemory _memory;

        public WordProcessor(IWordsFile file, IWordsMemory memory){
            _file = file;
            _memory = memory;
        }

        /**
         * get words from memory
         */
        public Words ListWords( string language )
        {     
            Language lang = _ValidateEnum( language );

            if( _memory.Exists( lang.ToString() ) ){
                return _memory.Read( lang.ToString() );
            }

            return ReadAndSave( lang );
        }

        /**
         * reads word from file and saves to memory
         */
        public Words ReadAndSave( Language language )
        {            
            string[] wordList = _file.Read( language.ToString() );

            Words words = new Words( wordList, language );

            _memory.Save( _file.FilePath(language.ToString()), words );

            return words;
        }

        /**
         * check if language exists else return default: DUTCH
         */
        private static Language _ValidateEnum( string language ){
            var upper = language.ToUpper();
            if( Enum.IsDefined(typeof(Language), upper) && Enum.TryParse(upper, out Language parsed) ){
                return parsed;
            }

            return Language.DUTCH;
        }

    }
}
