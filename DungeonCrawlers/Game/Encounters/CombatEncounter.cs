using DungeonCrawlersTests.Game.Locations;

namespace DungeonCrawlers.Game.Encounters
{
    public class CombatEncounter : Encounter
    {

        public CombatEncounter(IEnemyController enemyController)
        {
            EnemyController = enemyController;
            GenerateEncounter();
        }

        public IEnemyController EnemyController { get; private set; }

        public override void GenerateEncounter()
        {
            EnemyController.GenerateEnemies();
        }

        public override void RunEncounter()
        {
            throw new System.NotImplementedException();
        }
    }
}