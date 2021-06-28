using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.Systems.Interfaces
{
    public interface IMonsterCreationSystem
    {
        IEnumerable<IMonster> CreateMultiple(int quantity, int[] seeds);
    }
}