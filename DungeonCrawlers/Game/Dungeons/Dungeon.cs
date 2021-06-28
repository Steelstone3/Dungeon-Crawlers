using System;
using System.Collections.Generic;
using DungeonCrawlers.Contracts.Dungeons;
using DungeonCrawlers.Game.Dungeons;

namespace DungeonCrawlersTests
{
    public class Dungeon
    {
        private const int _maxNumberOfRooms = 10;
        private const int _maxNumberOfEncounters = 5;

        public Dungeon(int numberOfRooms)
        {
            GenerateRooms(numberOfRooms);
        }

        public IEnumerable<IRoom> Rooms{get; private set;}

        private void GenerateRooms(int numberOfRooms)
        {
            var rooms = new List<IRoom>();

            var limitedNumberOfRooms = SetRoomLimit(numberOfRooms);

            for (int i = 0; i < limitedNumberOfRooms; i++)
            {
                rooms.Add(new Room(new Random().Next(1, _maxNumberOfEncounters)));
            }

            Rooms = rooms;
        }

        private int SetRoomLimit(int numberOfRooms)
        {
            if(numberOfRooms > _maxNumberOfRooms)
            {
                return _maxNumberOfRooms;
            }
            else
            {
                return numberOfRooms;
            }
        }
    }
}