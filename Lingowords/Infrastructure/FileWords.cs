using System;
using System.IO;
using System.Reflection;

namespace Lingowords
{
    /**
     * Implementation of IWordsReader
     */ 
    public class FileWords : IWordsFile
    {
        public FileWords(){

        }

        public bool Exists( string language )
        {
            return File.Exists( FilePath(language) );
        }

        public string[] Read(string language)
        {
            if( Exists(language))
            {
                return File.ReadAllLines( FilePath(language) );
            }

            return new string[] { };
        }

        public string FilePath(string language, string name = "WORDS", string ext = "txt")
        {
            string temp = "LANGHOLDER-NAMEHOLDER.EXTENSION";
            temp = temp.Replace("LANGHOLDER", language);
            temp = temp.Replace("NAMEHOLDER", name);
            temp = temp.Replace("EXTENSION", ext);

            return Path.Combine(Directory.GetCurrentDirectory(), @"Files\", temp);
        }
    }
}
