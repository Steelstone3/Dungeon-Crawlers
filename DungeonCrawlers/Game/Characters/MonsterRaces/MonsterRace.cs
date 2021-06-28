using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.Game.Characters.MonsterRaces
{
    public abstract class MonsterRace : IMonsterRace
    {
        public string Name{get; protected set;}
        public string Description{get;protected set;}
        public IBiome Biome{get;protected set;}
    }
}