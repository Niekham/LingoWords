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
        public Words ListWords( string language, bool common = false )
        {     
            Language lang = _ValidateEnum( language );

            string key = lang.ToString() + (common ? "-COMMON" : ""); 

            if( _memory.Exists( key ) ){

                Words words = _memory.Read( key );

                return words;
            }

            return ReadAndSave( lang, key );
        }

        /**
         * reads word from file and saves to memory
         */
        public Words ReadAndSave( Language language, string key )
        {            
            string[] wordList = _file.Read( key );

            Words words = new Words( wordList, language );

            _memory.Save( _file.FilePath(key), words );

            return words;
        }

        /**
         * check if language exists else return default: DUTCH
         */
        private Language _ValidateEnum( string language ){
            var upper = language.ToUpper();
            if( Enum.IsDefined(typeof(Language), upper) && Enum.TryParse(upper, out Language parsed) ){
                return parsed;
            }

            return Language.DUTCH;
        }

    }
}
