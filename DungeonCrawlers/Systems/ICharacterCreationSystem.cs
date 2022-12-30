using System.Collections.Generic;
using System.Diagnostics.Metrics;
using DungeonCrawlers.Entities;

namespace DungeonCrawlersTests.Systems
{
    public interface ICharacterCreationSystem
    {
        ICharacter Create();
        IEnumerable<ICharacter> CreateMultiple(byte quantity, int[] seeds);
    }
}