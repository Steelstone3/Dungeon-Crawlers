using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Encounters;
using DungeonCrawlers.Game.Encounters;

namespace DungeonCrawlers.Builders
{
    public class EncounterBuilder : IEncounterBuilder
    {
        public IEnumerable<IHostileEncounter> BuildCombatEncounters(IEnemyController enemyController)
        {
            var random = new Random();

            for (int i = 0; i < random.Next(1, 5); i++)
            {
                yield return new CombatEncounter(enemyController);
            }
        }
    }
}