using System.Collections.Generic;
using DungeonCrawlers.Game.Locations.Rooms;
using DungeonCrawlersTests.Game.Locations;

namespace DungeonCrawlers.Contracts.Builders
{
    public interface IEncounterBuilder
    {
        IEnumerable<IEncounter> BuildCombatEncounters(IEnemyController enemyController);
    }
}