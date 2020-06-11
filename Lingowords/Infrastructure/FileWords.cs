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

            return new string[] { "error" };
        }

        public string FilePath(string language, string folder = "Files", string name = "WORDS", string ext = "txt")
        {
            string temp = "LANGHOLDER-NAMEHOLDER.EXTENSION";
            temp = temp.Replace("LANGHOLDER", language);
            temp = temp.Replace("NAMEHOLDER", name);
            temp = temp.Replace("EXTENSION", ext);

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), folder, temp);

            if( File.Exists(path))
            {
                return path;
            }

            return  Path.Combine(Directory.GetCurrentDirectory(), "Files", temp);
        }
    }
}
