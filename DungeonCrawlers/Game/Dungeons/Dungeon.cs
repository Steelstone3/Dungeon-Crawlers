using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Dungeons;
using DungeonCrawlers.Game.Dungeons;

namespace DungeonCrawlersTests
{
    public class Dungeon
    {
        private const int _maxNumberOfRooms = 10;
        private const int _minNumberOfRooms = 1;
        private const int _maxNumberOfEncounters = 5;
        private const int _minNumberOfEncounters = 1;

        public Dungeon(int numberOfRooms)
        {
            GenerateRooms(numberOfRooms);
        }

        public IEnumerable<IRoom> Rooms { get; private set; }

        private void GenerateRooms(int numberOfRooms)
        {
            var rooms = new List<IRoom>();

            var limitedNumberOfRooms = SetRoomLimit(numberOfRooms);

            for (int i = 0; i < limitedNumberOfRooms; i++)
            {
                rooms.Add(new Room(new Random().Next(_minNumberOfEncounters, _maxNumberOfEncounters)));
            }

            Rooms = rooms;
        }

        private int SetRoomLimit(int numberOfRooms)
        {
            if (numberOfRooms > _maxNumberOfRooms)
            {
                return _maxNumberOfRooms;
            }
            else if (numberOfRooms < 0)
            {
                return _minNumberOfRooms;
            }
            else
            {
                return numberOfRooms;
            }
        }
    }
}