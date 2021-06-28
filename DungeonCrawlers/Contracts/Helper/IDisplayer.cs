using System.Collections.Generic;

namespace DungeonCrawlersTests.Helpers
{
    public interface IDisplayer
    {
        void WriteMenu(IEnumerable<string> menu);
        void Write(string text);
        string Read();
        string Read(string message);
    }
}