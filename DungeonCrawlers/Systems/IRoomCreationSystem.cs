using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface IRoomCreationSystem
    {
        List<IRoom> CreateRooms();
    }
}