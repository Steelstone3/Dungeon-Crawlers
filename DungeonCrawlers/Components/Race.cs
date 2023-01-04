namespace DungeonCrawlers.Components
{
    public class Race : IRace
    {
        public Race(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}