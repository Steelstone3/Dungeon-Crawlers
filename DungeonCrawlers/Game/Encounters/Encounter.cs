using DungeonCrawlers.Game.Locations.Rooms;

namespace DungeonCrawlers.Game.Encounters
{
    public abstract class Encounter : IEncounter
    {
        public abstract void GenerateEncounter();
        public abstract void RunEncounter();
    }
}