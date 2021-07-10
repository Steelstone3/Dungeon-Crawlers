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
        public IList<IMonster> EnemyParty{get; private set;}

        public void GenerateEnemies()
        {
            EnemyParty = new List<IMonster>()
            {
                new Monster(new Goblin()),
                new Monster(new Goblin()),
                new Monster(new Goblin()),
                new Monster(new Goblin()),
            };
        }

        public void DisplayEnemyParty(IDisplayer displayer)
        {
            foreach (var enemy in EnemyParty)
            {
                displayer.Write($"{enemy.Name} the {enemy.Race.Name}");
            }
        }
    }
}