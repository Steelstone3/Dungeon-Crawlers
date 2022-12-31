using System;
using System.Collections.Generic;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Presenters;

namespace DungeonCrawlers.Systems
{
    public class CombatSystem : ICombatSystem
    {
        private readonly IPresenter presenter;
        private readonly ISeededRandomSystem random;

        public CombatSystem(IPresenter presenter, ISeededRandomSystem random)
        {
            this.presenter = presenter;
            this.random = random;
        }

        public void MonsterTurn()
        {
            throw new NotImplementedException();
        }

        public void PlayerTurn(IEnumerable<ICharacter> characters, IEnumerable<IMonster> monsters)
        {
            presenter.PrintParty(characters);

            var character = presenter.SelectCharacter(characters);
            var monster = presenter.SelectMonster(monsters);

            var damage = CalculateDamage(character.Weapon);
            AssignDamage(monster.Health, damage);

            presenter.Print($"{character.Name.FirstName} {character.Name.Surname} used {character.Weapon.Name} and {character.Weapon.AttackDescription} {monster.Name.FirstName} {monster.Name.Surname} for {damage} damage");
            
            presenter.PrintParty(monsters);
        }

        private static byte CalculateDamage(IWeapon weapon) => (byte)new Random().Next(weapon.MinimumDamage, weapon.MaximumDamage);

        private static void AssignDamage(IHealth health, byte damage)
        {
            if (health.CurrentHealth > damage)
            {
                health.CurrentHealth -= damage;
            }
            else
            {
                health.CurrentHealth = 0;
            }
        }
    }
}