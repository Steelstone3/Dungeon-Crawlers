using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;

namespace DungeonCrawlers.Game.Locations.Rooms
{
    public class DungeonRoom : Room
    {
        public DungeonRoom(IEncounterBuilder encounterBuilder, IEnemyController enemyController)
        {
            Encounters = encounterBuilder.BuildCombatEncounters(enemyController);
        }
    }
}