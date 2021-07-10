using DungeonCrawlers.Contracts.Controllers;

namespace DungeonCrawlers.Contracts.Game.Encounters
{
    public interface IHostileEncounter : IEncounter
    {
        IEnemyController EnemyController { get;}
    }
}