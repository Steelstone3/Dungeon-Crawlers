using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.States
{
    public class GameState : IGameState
    {
        public IEnumerable<ICharacter> CharacterParty { get; set; } = new List<ICharacter>();
    }
}