using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Game.Locations.Rooms;

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
            Rooms = GenerateRooms();
        }

        public IList<IDungeonRoom> Rooms { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private IList<IDungeonRoom> GenerateRooms()
        {
            var rooms = new List<IDungeonRoom>();

            var random = new Random();

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                rooms.Add(new DungeonRoom(_encounterBuilder, _enemyController));
            }

            return rooms;
        }
    }
}