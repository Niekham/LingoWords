using System;
using System.IO;

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

            var path = Path.Combine(Path.GetFullPath("Files"), temp);
            if (File.Exists(path))
            {
                return path;
            }

            path = Directory.GetCurrentDirectory();
            var index = path.IndexOf("Lingowords");
            return path.Substring(0, index + ("Lingowords".Length)) + "\\Lingowords\\Files\\" + temp;
        }
    }
}
