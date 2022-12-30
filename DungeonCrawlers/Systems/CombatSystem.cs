using DungeonCrawlers.Entities;

namespace DungeonCrawlers.Systems
{
    public class CombatSystem : ICombatSystem
    {
        public void MonsterTurn()
        {
            throw new System.NotImplementedException();
        }

        public void PlayerTurn(ICharacter character, IMonster monster)
        {
            monster.Health.CurrentHealth -= (byte)character.Weapon.MaximumDamage;
        }
    }
}