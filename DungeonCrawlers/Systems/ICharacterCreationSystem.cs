using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlersTests.Systems
{
    public interface ICharacterCreationSystem
    {
        ICharacter Create();
        IEnumerable<ICharacter> CreateMultiple(byte quantity, int[] seeds);
    }
}