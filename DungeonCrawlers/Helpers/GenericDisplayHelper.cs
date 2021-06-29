using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Helper;

namespace DungeonCrawlers.Helpers
{
    public class GenericDisplayHelper : IGenericDisplayHelper
    {
        public int ReadUserNumericInput(string message, int lowerBound, int upperBound)
        {
            string input;
            int validValue;

            do
            {
                input = ReadUserString(message);
            } while (!int.TryParse(input, out validValue) || validValue < lowerBound || validValue > upperBound);

            return validValue;
        }

        public double ReadUserNumericInput(string message, double lowerBound, double upperBound)
        {
            string input;
            double validValue;

            do
            {
                input = ReadUserString(message);
            } while (!double.TryParse(input, out validValue) || validValue < lowerBound || validValue > upperBound);

            return validValue;
        }

        public string ReadUserString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public string ReadUserString()
        {
            return Console.ReadLine();
        }

        public void DisplayMenu(IEnumerable<string> menu)
        {
            foreach (var menuItem in menu)
            {
                Console.WriteLine(menuItem);
            }
        }

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
    }
}