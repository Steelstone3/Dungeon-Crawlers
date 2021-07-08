using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlersTests.Game.Locations;

namespace DungeonCrawlers.Game.Locations.Rooms
{
    public class DungeonRoom : Room
    {
        public DungeonRoom(IEncounterBuilder encounterBuilder, IEnemyController enemyController)
        {
            Encounters = GenerateEncounters(encounterBuilder, enemyController);
        }

        private IEnumerable<IEncounter> GenerateEncounters(IEncounterBuilder encounterBuilder, IEnemyController enemyController)
        {
            return encounterBuilder.BuildCombatEncounters(enemyController);
        }
    }
}