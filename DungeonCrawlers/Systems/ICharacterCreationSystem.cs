using DungeonCrawlers.Components.Character;
using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface ICharacterCreationSystem
    {
        Character Create(IDisplayer displayer);
    }
}