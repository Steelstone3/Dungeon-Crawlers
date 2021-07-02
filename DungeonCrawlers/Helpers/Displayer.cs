using System;
using DungeonCrawlers.Contracts;

namespace DungeonCrawlersTests
{
    public class Displayer : IDisplayer
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}