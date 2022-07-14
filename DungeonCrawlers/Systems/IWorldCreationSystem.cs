using DungeonCrawlers.Display;

namespace DungeonCrawlers.States
{
    public interface IWorldCreationSystem
    {
        IWorld Create(IDisplayer @object);
    }
}