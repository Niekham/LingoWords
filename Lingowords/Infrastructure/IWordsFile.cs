// I just added a comment because for some reason my file gets ignored. thanks.
namespace Lingowords{
    public interface IWordsFile
    {
        bool Exists(string key);

        string[] Read(string key);

        string FilePath( string language, string folder = "Files", string ext = "txt" );
    }
}