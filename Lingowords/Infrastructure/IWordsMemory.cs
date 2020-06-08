namespace Lingowords{
    public interface IWordsMemory
    {
        bool Exists( string path );
        Words Read( string path );
        void Save( string path, Words words );
        
    }
}