using DungeonCrawlers.States;

namespace DungeonCrawlers.Entities
{
    public class World : IWorld
    {
        public World() {
            worldGrid = new char[,]{{'#', '#'}, {'#', '#'}};
        }

        public char[,] worldGrid { get; }
    }
}