using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Characters;

namespace DungeonCrawlersTests.Game.Locations
{
    public interface IEnemyController
    {
        IList<IMonster> EnemyParty{get;}
        void GenerateEnemies();
    }
}