using System.Collections.Generic;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;

namespace DungeonCrawlers.Systems
{
    public class CombatSystem : ICombatSystem
    {
        private readonly IPresenter presenter;

        public CombatSystem(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void MonsterTurn()
        {
            throw new System.NotImplementedException();
        }

        public void PlayerTurn(IEnumerable<ICharacter> characters, IEnumerable<IMonster> monsters)
        {
            var character = presenter.SelectCharacter(characters);
            var monster = presenter.SelectMonster(monsters);
            
            monster.Health.CurrentHealth -= (byte)character.Weapon.MaximumDamage;
        }
    }
}