using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.Systems.Interfaces
{
    public interface ICharacterCreationSystem
    {
        ICharacter Create();
        IEnumerable<ICharacter> CreateMultiple(byte quantity, int[] seeds);
    }
}