using System;
using System.Collections.Generic;

namespace DungeonCrawlers.Display
{
    public class Displayer : IDisplayer
    {
        public int ReadNumeric(string message, int lowerBound, int upperBound)
        {
            string input;
            int validValue;

            do
            {
                input = ReadString(message);
            } while (!int.TryParse(input, out validValue) || validValue < lowerBound || validValue > upperBound);

            return validValue;
        }

        public double ReadNumeric(string message, double lowerBound, double upperBound)
        {
            string input;
            double validValue;

            do
            {
                input = ReadString(message);
            } while (!double.TryParse(input, out validValue) || validValue < lowerBound || validValue > upperBound);

            return validValue;
        }

        public string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteMenu(IList<string> menuItems)
        {
            foreach (var item in menuItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}