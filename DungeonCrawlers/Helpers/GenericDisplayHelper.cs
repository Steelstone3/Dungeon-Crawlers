using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Helper;
using DungeonCrawlersTests.Helpers;

namespace DungeonCrawlers.Helpers
{
    public class GenericDisplayHelper : IGenericDisplayHelper
    {
        private IDisplayer _displayer;

        public GenericDisplayHelper(IDisplayer displayer)
        {
            _displayer = displayer;
        }

        public int ReadUserNumericInput(string message, int lowerBound, int upperBound)
        {
            string input;
            int validValue;

            do
            {
                input = _displayer.Read(message);
            } while (!int.TryParse(input, out validValue) || validValue < lowerBound || validValue > upperBound);

            return validValue;
        }

        public double ReadUserNumericInput(string message, double lowerBound, double upperBound)
        {
            string input;
            double validValue;

            do
            {
                input = _displayer.Read(message);
            } while (!double.TryParse(input, out validValue) || validValue < lowerBound || validValue > upperBound);

            return validValue;
        }

        public string ReadUserText(string message)
        {
            return _displayer.Read(message);
        }

        public string ReadUserText()
        {
            return _displayer.Read();
        }

        public void DisplayMenu(IEnumerable<string> menu)
        {
            _displayer.WriteMenu(menu);
        }

        public void DisplayText(string text)
        {
            _displayer.Write(text);
        }

        #region Wrapper for unit testing

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

        #endregion
    }
}