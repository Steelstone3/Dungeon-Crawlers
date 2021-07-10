using System.Collections.Generic;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Encounters;

namespace DungeonCrawlers.Contracts.Builders
{
    public interface IEncounterBuilder
    {
        IEnumerable<IHostileEncounter> BuildCombatEncounters(IEnemyController enemyController);
    }
}