namespace DungeonCrawlers.Contracts.Game.Characters.Race
{
    public interface IMonsterRace : IRace
    {
        int Health{get; set;}
        int Damage { get; }
        //IBiome Biome{get;}
    }
}