using DungeonCrawlers.Contracts.General;

namespace DungeonCrawlers.Contracts
{
    public interface IMonsterRace : IHeader
    {
        IBiome Biome{get;}
    }
}