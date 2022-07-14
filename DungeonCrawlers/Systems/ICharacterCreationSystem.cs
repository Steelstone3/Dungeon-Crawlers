using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface ICharacterCreationSystem
    {
        ICharacter Create(IDisplayer displayer);
    }
}