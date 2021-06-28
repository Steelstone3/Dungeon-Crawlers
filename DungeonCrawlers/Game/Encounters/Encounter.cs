using DungeonCrawlers.Contracts.Encounters;

namespace DungeonCrawlers.Game.Encounters
{
    public abstract class Encounter : IEncounter
    {
        protected abstract void GenerateEncounter();
    }
}