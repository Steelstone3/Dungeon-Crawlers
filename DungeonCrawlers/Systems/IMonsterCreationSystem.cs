using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface IMonsterCreationSystem
    {
        IEnumerable<IMonster> CreateMultiple(int quantity, int[] seeds);
    }
}