using DungeonCrawlers.Contracts.Game.Characters.Race;
using DungeonCrawlers.Contracts.Helpers;

namespace DungeonCrawlers.Contracts.Game.Characters
{
    public interface IMonster : IHeader
    {
        IMonsterRace Race{get;}
    }
}