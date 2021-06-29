using System.Collections.Generic;

namespace DungeonCrawlers.Contracts.Helper
{
    public interface IGenericDisplayHelper
    {
        int ReadUserNumericInput(string message, int lowerBound, int upperBound);
        double ReadUserNumericInput(string message, double lowerBound, double upperBound);
        string ReadUserString(string message);
        string ReadUserString();
        void DisplayMenu(IEnumerable<string> menu);
        void DisplayText(string text);
    }
}