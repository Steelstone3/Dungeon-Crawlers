using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.States
{
    public interface IGameRepository
    {
        List<ICharacter> CharacterParty { get; }
        List<IMonster> MonsterParty { get; }
    }
}