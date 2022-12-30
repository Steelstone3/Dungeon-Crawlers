using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.States
{
    public class GameState : IGameState
    {
        public List<ICharacter> CharacterParty { get; } = new List<ICharacter>();
        public List<IMonster> MonsterParty { get; } = new List<IMonster>();
    }
}