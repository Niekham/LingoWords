namespace Lingowords{
    public interface IProcessor
    {
        Words ListWords( string language, bool common = false );
        Words ReadAndSave( Language language, string key );
    }
}