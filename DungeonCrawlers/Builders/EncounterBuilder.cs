using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Game.Encounters;
using DungeonCrawlers.Game.Locations.Rooms;
using DungeonCrawlersTests.Game.Locations;

namespace DungeonCrawlers.Builders
{
    public class EncounterBuilder : IEncounterBuilder
    {
        public IEnumerable<IEncounter> BuildCombatEncounters(IEnemyController enemyController)
        {
            var random = new Random();

            for (int i = 0; i < random.Next(1, 5); i++)
            {
                yield return new CombatEncounter(enemyController);
            }
        }
    }
}