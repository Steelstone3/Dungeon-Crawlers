using System.Collections.Generic;
using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface ICombatSystem
    {
        void MonsterTurn();
        void PlayerTurn(IEnumerable<ICharacter> characters, IEnumerable<IMonster> monsters);
    }
}