using System.Collections.Generic;

namespace DungeonCrawlers.Display
{
    public interface IDisplayer
    {
        void Write(string message);
        string ReadString(string message);
        void WriteMenu(IList<string> menuItems);
        int ReadNumeric(string message, int lowerBound, int upperBound);
        double ReadNumeric(string message, double lowerBound, double upperBound);
        void DrawMap(char[,] worldGrid);
    }
}