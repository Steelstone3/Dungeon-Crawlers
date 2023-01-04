using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlersTests.Entities;

namespace DungeonCrawlers.States
{
    public interface IGameRepository
    {
        List<ICharacter> CharacterParty { get; }
        IDungeon Dungeon { get; set; }
    }
}