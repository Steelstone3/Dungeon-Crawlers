using System.Collections;
using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.States
{
    public interface IGameState
    {
        List<ICharacter> CharacterParty { get; }
    }
}