using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.Game.Exploration
{
    public class Biome : IBiome
    {
        public string Name {get;protected set;}
        public string Description {get; protected set;}
    }
}