namespace DungeonCrawlers.Presenters
{
    public interface IPresenter
    {
        void Print(string message);
        byte GetByte(string message);
        byte GetByte(string message, byte lowerBound, byte upperBound);
        string GetString(string message);
        string SelectString(string message, string[] options);
        bool GetConfirmation(string message);
    }
}