using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Encounters;

namespace DungeonCrawlers.Game.Encounters
{
    public class CombatEncounter : IHostileEncounter
    {
        public CombatEncounter(IEnemyController enemyController)
        {
            EnemyController = enemyController;
            GenerateEncounter();
        }

        public IEnemyController EnemyController { get; private set; }

        public void GenerateEncounter()
        {
            EnemyController.GenerateEnemies();
        }
    }
}