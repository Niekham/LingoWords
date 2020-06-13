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

        public bool Exists( string key )
        {
            return File.Exists( FilePath(key) );
        }

        public string[] Read(string key)
        {
            if( Exists(key))
            {
                return File.ReadAllLines( FilePath(key) );
            }

            return new string[] { "error" };
        }

        public string FilePath(string key, string folder = "Resources", string ext = "txt")
        {
            string temp = "KEYHOLDER.EXTENSION";
            temp = temp.Replace("KEYHOLDER", key);
            temp = temp.Replace("EXTENSION", ext);

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), folder, temp);

            if( File.Exists(path))
            {
                return path;
            }

            return  Path.Combine(Directory.GetCurrentDirectory(), "Resources", temp);
        }
    }
}
