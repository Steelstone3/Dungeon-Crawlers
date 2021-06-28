using System.Collections.Generic;
using DungeonCrawlers.Contracts.Dungeons;
using DungeonCrawlers.Contracts.Encounters;
using DungeonCrawlers.Game.Encounters;

namespace DungeonCrawlers.Game.Dungeons
{
    public class Room : IRoom
    {
        private const int _maxNumberOfEncounters = 5;

        public Room(int numberOfEncounters)
        {
            GenerateEncounters(numberOfEncounters);
        }

        public IEnumerable<IEncounter> Encounters { get; private set; }

        private void GenerateEncounters(int numberOfEncounters)
        {
            var encounters = new List<IEncounter>();

            var limitedNumberOfRooms = SetEncounterLimit(numberOfEncounters);

            for (int i = 0; i < limitedNumberOfRooms; i++)
            {
                encounters.Add(new CombatEncounter());
            }

            Encounters = encounters;
        }

        private int SetEncounterLimit(int numberOfEncounters)
        {
            if (numberOfEncounters > _maxNumberOfEncounters)
            {
                return _maxNumberOfEncounters;
            }
            else
            {
                return numberOfEncounters;
            }
        }
    }
}