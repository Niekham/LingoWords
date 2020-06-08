namespace Lingowords{
    public interface IProcessor
    {
        Words ListWords( string language );
        Words ReadAndSave( Languages language );
    }
}