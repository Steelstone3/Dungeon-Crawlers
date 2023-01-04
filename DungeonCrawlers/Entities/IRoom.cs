using System.Collections.Generic;

namespace DungeonCrawlers.Entities
{
    public interface IRoom
    {
        IEnumerable<IMonster> Monsters { get; }
    }
}