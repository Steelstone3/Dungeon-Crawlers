using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;

namespace DungeonCrawlers.Contracts.Services
{
    public interface IDungeonService
    {
        IDungeon SelectDungeon(IDisplayer displayer, 
        ILocationService locationService, 
        IDungeonController dungeonController, 
        IDungeonBuilder dungeonBuilder);
        void StartDungeon(IDisplayer displayer, 
        ICombatService combatService, 
        ICombatController combatController, 
        ICharacterController characterController, 
        IDungeon dungeon);
    }
}