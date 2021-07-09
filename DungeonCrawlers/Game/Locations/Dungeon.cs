using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Game.Locations.Rooms;
using DungeonCrawlersTests.Game.Locations;

namespace DungeonCrawlers.Game.Locations
{
    public class Dungeon : IDungeon
    {
        private IEncounterBuilder _encounterBuilder;
        private IEnemyController _enemyController;

        public Dungeon(IEncounterBuilder encounterBuilder, IEnemyController enemyController)
        {
            Name = "A Dungeon";
            Description = string.Empty;
            _encounterBuilder = encounterBuilder;
            _enemyController = enemyController;
        }

        public IList<IRoom> Rooms => GenerateRooms();
        public string Name { get; private set; }
        public string Description { get; private set; }

        private IList<IRoom> GenerateRooms()
        {
            var rooms = new List<IRoom>();

            var random = new Random();

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                rooms.Add(new DungeonRoom(_encounterBuilder, _enemyController));
            }

            return rooms;
        }
    }
}