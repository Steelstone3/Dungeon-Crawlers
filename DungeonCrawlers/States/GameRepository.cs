using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlersTests.Entities;

namespace DungeonCrawlers.States
{
    public class GameRepository : IGameRepository
    {
        public List<ICharacter> CharacterParty { get; } = new List<ICharacter>();
        public IDungeon Dungeon { get; set; }
    }
}