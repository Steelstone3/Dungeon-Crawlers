using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlersTests.Entities;

namespace DungeonCrawlers.States
{
    public class GameRepository : IGameRepository
    {
        public List<ICharacter> CharacterParty { get; } = new List<ICharacter>();
        public List<IMonster> MonsterParty { get; } = new List<IMonster>();
        public IDungeon Dungeon { get; } = new Dungeon(new List<IRoom>());
    }
}