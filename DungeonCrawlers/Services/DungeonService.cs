using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Contracts.Services;

namespace DungeonCrawlers.Services
{
    public class DungeonService : IDungeonService
    {
        public IDungeon SelectDungeon(IDisplayer displayer, 
        ILocationService locationService, 
        IDungeonController dungeonController, 
        IDungeonBuilder dungeonBuilder)
        {
            dungeonController.Dungeons = locationService.GenerateDungeons(dungeonController, dungeonBuilder);
            locationService.DisplayLocations(displayer, dungeonController);
            return locationService.SelectLocation(displayer, dungeonController.Dungeons);
        }

        public void StartDungeon(IDisplayer displayer, 
        ICombatService combatService, 
        ICombatController combatController, 
        ICharacterController characterController, 
        IDungeon dungeon)
        {
            foreach (var room in dungeon.Rooms)
            {
                foreach (var encounter in room.Encounters)
                {
                    combatService.StartCombat(displayer, 
                    combatController,
                    characterController,
                    encounter.EnemyController);
                }
            }
        }
    }
}