using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.Systems.Interfaces
{
    public interface IRoomCreationSystem
    {
        List<IRoom> CreateRooms();
    }
}