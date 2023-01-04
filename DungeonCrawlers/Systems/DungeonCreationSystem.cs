using DungeonCrawlersTests.Entities;

namespace DungeonCrawlers.Systems
{
    public class DungeonCreationSystem : IDungeonCreationSystem
    {
        private IRoomCreationSystem roomCreationSystem;

        public DungeonCreationSystem(IRoomCreationSystem roomCreationSystem)
        {
            this.roomCreationSystem = roomCreationSystem;
        }

        public IDungeon CreateDungeon()
        {
            return new Dungeon(roomCreationSystem.CreateRooms());
        }
    }
}