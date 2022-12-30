using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public interface ICombatSystem
    {
        void MonsterTurn();
        void PlayerTurn(ICharacter character, IMonster monster);
    }
}