using DungeonCrawlers.Contracts.Game.Characters.Race;

namespace DungeonCrawlers.Game.Characters.Races.MonsterRaces
{
    public abstract class MonsterRace : IMonsterRace
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}