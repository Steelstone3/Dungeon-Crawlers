using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Systems.Interfaces;

namespace DungeonCrawlers.Systems
{
    public class RoomCreationSystem : IRoomCreationSystem
    {
        private readonly ISeededRandomSystem seededRandomSystem;
        private readonly IMonsterCreationSystem monsterCreationSystem;

        public RoomCreationSystem(ISeededRandomSystem seededRandomSystem, IMonsterCreationSystem monsterCreationSystem)
        {
            this.seededRandomSystem = seededRandomSystem;
            this.monsterCreationSystem = monsterCreationSystem;
        }

        public List<IRoom> CreateRooms()
        {
            List<IRoom> rooms = new();
            int roomQuantity = (int)seededRandomSystem.GetRandom(1, 10);

            for (int i = 0; i < roomQuantity; i++)
            {
                rooms.Add(CreateRoom());
            }

            return rooms;
        }

        private IRoom CreateRoom()
        {
            int monsterQuantity = (int)seededRandomSystem.GetRandom(1, 10);
            var seeds = seededRandomSystem.CreateSeeds(monsterQuantity);

            var monsters = monsterCreationSystem.CreateMultiple(monsterQuantity, seeds);

            return new Room(monsters);
        }
    }
}