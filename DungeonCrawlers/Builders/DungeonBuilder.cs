using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Game.Locations;
using DungeonCrawlersTests.Game.Locations;

namespace DungeonCrawlers.Builders
{
    public class DungeonBuilder : IDungeonBuilder
    {
        private IEncounterBuilder _encounterBuilder;
        private IEnemyController _enemyController;

        public DungeonBuilder(IEncounterBuilder encounterBuilder, IEnemyController enemyController)
        {
            _encounterBuilder = encounterBuilder;
            _enemyController = enemyController;
        }

        public IList<IDungeon> BuildDungeons()
        {
            var dungeons = new List<IDungeon>();
            
            var random = new Random();

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                dungeons.Add(new Dungeon(_encounterBuilder, _enemyController));
            }

            return dungeons;
        }
    }
}