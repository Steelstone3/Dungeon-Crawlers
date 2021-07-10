using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Characters;

namespace DungeonCrawlers.Contracts.Controllers
{
    public interface IEnemyController
    {
        IList<IMonster> EnemyParty { get; }
        void GenerateEnemies();
    }
}