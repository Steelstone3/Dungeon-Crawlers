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

        public void PlayerTurn(IEnumerable<ICharacter> characters, IEnumerable<IMonster> monsters)
        {
            presenter.PrintParty(characters);

            var character = presenter.SelectCharacter(characters);
            var monster = presenter.SelectMonster(monsters);
            var damage = CalculateDamage(character.Weapon);
            character.Health.CurrentHealth = AssignDamage(monster.Health, damage);

            presenter.Print($"{character.Name.FirstName} {character.Name.Surname} used {character.Weapon.Name} and {character.Weapon.AttackDescription} {monster.Name.FirstName} {monster.Name.Surname} for {damage} damage");
            presenter.PrintParty(monsters);
        }

        public void MonsterTurn(IEnumerable<IMonster> monsters, IEnumerable<ICharacter> characters)
        {
            presenter.PrintParty(monsters);

            var monster = random.SelectRandom(monsters);
            var character = random.SelectRandom(characters);
            var damage = CalculateDamage(monster.Weapon);
            character.Health.CurrentHealth = AssignDamage(character.Health, damage);

            presenter.Print($"{monster.Name.FirstName} {monster.Name.Surname} used {monster.Weapon.Name} and {monster.Weapon.AttackDescription} {character.Name.FirstName} {character.Name.Surname} for {damage} damage"); 
            presenter.PrintParty(characters);
        }

        private static byte CalculateDamage(IWeapon weapon) => (byte)new Random().Next(weapon.MinimumDamage, weapon.MaximumDamage);
        private static byte AssignDamage(IHealth health, byte damage) => health.CurrentHealth > damage ? (health.CurrentHealth -= damage) : (health.CurrentHealth = 0);
    }
}