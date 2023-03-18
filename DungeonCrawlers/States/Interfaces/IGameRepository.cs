using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.States.Interfaces
{
    public interface IGameRepository
    {
        List<ICharacter> CharacterParty { get; }
        IDungeon Dungeon { get; set; }
    }
}