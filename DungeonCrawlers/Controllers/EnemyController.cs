using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Characters;
using DungeonCrawlers.Game.Characters.Enemies;
using DungeonCrawlers.Game.Enemies;

namespace DungeonCrawlers.Controllers
{
    public class EnemyController : IEnemyController
    {
        public IList<IMonster> PartyMembers { get; private set; }

        public void GenerateEnemies()
        {
            PartyMembers = new List<IMonster>()
            {
                new Monster(new Goblin()),
                new Monster(new Goblin()),
                new Monster(new Goblin()),
                new Monster(new Goblin()),
            };
        }

        public void DisplayParty(IDisplayer displayer)
        {
            foreach (var enemy in PartyMembers)
            {
                displayer.Write($"Health: {enemy.Race.Health}, {enemy.Name} the {enemy.Race.Name}");
            }
        }

        public ICharacter SelectOpponent(IDisplayer displayer, IList<ICharacter> partyMembers)
        {
            var random = new Random();
            return partyMembers[random.Next(0, partyMembers.Count - 1)];
        }

        public void AttackOpponent(ICharacter character)
        {
            character.CombatRole.Health -= SelectPlayer().Race.Damage;
        }

        private IMonster SelectPlayer()
        {
            var random = new Random();
            return PartyMembers[random.Next(0, PartyMembers.Count - 1)];
        }
    }
}