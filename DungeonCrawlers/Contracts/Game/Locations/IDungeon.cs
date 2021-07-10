using System.Collections.Generic;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Helpers;

namespace DungeonCrawlers.Contracts.Game.Locations
{
    public interface IDungeon : IHeader
    {
        IList<IDungeonRoom> Rooms { get; }
        void StartDungeon(IList<IDungeonRoom> rooms, ICombatController combatController);
    }
}