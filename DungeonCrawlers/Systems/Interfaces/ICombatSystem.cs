using System.Collections.Generic;
using DungeonCrawlers.Entities.Intefaces;

namespace DungeonCrawlers.Systems.Interfaces
{
    public interface ICombatSystem
    {
        bool MonsterTurn(IEnumerable<IMonster> monsters, IEnumerable<ICharacter> characters);
        bool PlayerTurn(IEnumerable<ICharacter> characters, IEnumerable<IMonster> monsters);
    }
}