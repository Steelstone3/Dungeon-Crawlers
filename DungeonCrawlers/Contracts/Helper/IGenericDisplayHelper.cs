using System.Collections.Generic;

namespace DungeonCrawlers.Contracts.Helper
{
    public interface IGenericDisplayHelper
    {
        int ReadUserNumericInput(string message, int lowerBound, int upperBound);
        double ReadUserNumericInput(string message, double lowerBound, double upperBound);
        string ReadUserText(string message);
        string ReadUserText();
        void DisplayMenu(IEnumerable<string> menu);
        void DisplayText(string text);

        void WriteMenu(IEnumerable<string> menu);
        void Write(string text);
        string Read();
        string Read(string message);
    }
}