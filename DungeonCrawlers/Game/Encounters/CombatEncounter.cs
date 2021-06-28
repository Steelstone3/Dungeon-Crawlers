using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Game.Characters.MonsterRaces;

namespace DungeonCrawlers.Game.Encounters
{
    public class CombatEncounter : Encounter
    {
        public CombatEncounter()
        {
            GenerateEncounter();
        }

        public IEnumerable<IMonsterRace> Monsters;

        //TODO AH generate based on biomes
        protected override void GenerateEncounter()
        {
            Monsters = new List<IMonsterRace>()
            {
                new Goblin(),
                new Goblin(),
                new Goblin(),
                new Goblin(),
            };
        }
    }
}