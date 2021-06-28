using System.Collections.Generic;

namespace DungeonCrawlers.Entities.Intefaces
{
    public interface IRoom
    {
        IEnumerable<IMonster> Monsters { get; }
    }
}