using DungeonCrawlers.Components;

namespace DungeonCrawlersTests.Components
{
    public class Name : IName
    {
        public Name(string prefix, string firstName, string surname, string suffix)
        {
            Prefix = prefix;
            FirstName = firstName;
            Surname = surname;
            Suffix = suffix;
        }

        public string Prefix { get; }
        public string FirstName { get; }
        public string Surname { get; }
        public string Suffix { get; }
    }
}