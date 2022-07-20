using DungeonCrawlers.Entities;

namespace DungeonCrawlers.States
{
    public interface IWorldCreationSystem
    {
        IWorld Create();
    }
}