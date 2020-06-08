using System;
using System.IO;

namespace Lingowords
{
    /**
     * Implementation of IWordsReader
     */ 
    class FileWords : IWordsFile
    {
        public FileWords(){

        }
        public bool Exists( string language )
        {
            return File.Exists( FilePath(language) );
        }

        public string[] Read(string language)
        {
            var lines = File.ReadAllLines( FilePath(language) );
            return lines;
        }

        public string FilePath( string language, string name = "WORDS", string ext = "txt" ){
            string temp = "LANGHOLDER-NAMEHOLDER.EXTENSION";
            temp = temp.Replace("LANGHOLDER", language);
            temp = temp.Replace("NAMEHOLDER", name);
            temp = temp.Replace("EXTENSION", ext);

            return Path.Combine(Environment.CurrentDirectory, @"Words\", temp);
        }
    }
}
