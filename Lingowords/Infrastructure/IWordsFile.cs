// I just added a comment because for some reason my file gets ignored. thanks.
namespace Lingowords{
    public interface IWordsFile
    {
        bool Exists( string language );

        string[] Read(string language);

        string FilePath( string language, string folder = "Files", string name = "WORDS", string ext = "txt" );
    }
}