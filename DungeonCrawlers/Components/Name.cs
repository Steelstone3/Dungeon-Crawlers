using DungeonCrawlers.Components.Interfaces;

namespace DungeonCrawlers.Components
{
    public class Name : IName
    {
        public Name(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public string FirstName { get; }
        public string Surname { get; }
    }
}