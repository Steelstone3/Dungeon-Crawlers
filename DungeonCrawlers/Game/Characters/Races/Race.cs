using DungeonCrawlers.Contracts.Game.Characters.Race;

namespace DungeonCrawlers.Game.Characters.Races
{
    public abstract class Race : IRace
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}