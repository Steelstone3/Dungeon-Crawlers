using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface ICombatSystem
    {
        bool MonsterTurn(IEnumerable<IMonster> monsters, IEnumerable<ICharacter> characters);
        bool PlayerTurn(IEnumerable<ICharacter> characters, IEnumerable<IMonster> monsters);
    }
}