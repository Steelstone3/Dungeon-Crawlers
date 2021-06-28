using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.States.Interfaces;

namespace DungeonCrawlers.States
{
    public class GameRepository : IGameRepository
    {
        public List<ICharacter> CharacterParty { get; } = new List<ICharacter>();
        public IDungeon Dungeon { get; set; }
    }
}