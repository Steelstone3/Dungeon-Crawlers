using System.Collections.Generic;
using DungeonCrawlers.Contracts.Helpers;

namespace DungeonCrawlers.Contracts.Game.Locations
{
    public interface IDungeon : IHeader
    {
        IList<IRoom> Rooms { get; }
        void StartDungeon();
    }
}