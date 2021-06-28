using System;
using System.Collections.Generic;
using DungeonCrawlersTests.Helpers;

namespace DungeonCrawlers.Helpers
{
    public class Displayer : IDisplayer
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteMenu(IEnumerable<string> menu)
        {
            foreach (var menuItem in menu)
            {
                Console.WriteLine(menuItem);
            }
        }

        public string Read()
        {
            return Console.ReadLine();
        }

        public string Read(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}