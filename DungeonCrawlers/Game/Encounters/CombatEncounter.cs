using DungeonCrawlers.Controllers;
using DungeonCrawlersTests.Game.Locations;

namespace DungeonCrawlers.Game.Encounters
{
    public class CombatEncounter : Encounter
    {
        private IEnemyController _enemyController;

        public CombatEncounter(IEnemyController enemyController)
        {
            _enemyController = enemyController;
            GenerateEncounter();
        }

        public EnemyController EnemyParty { get; private set; }

        public override void GenerateEncounter()
        {
            _enemyController.GenerateEnemies();
        }
    }
}