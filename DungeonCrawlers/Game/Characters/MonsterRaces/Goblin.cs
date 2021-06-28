using DungeonCrawlers.Game.Exploration;

namespace DungeonCrawlers.Game.Characters.MonsterRaces
{
    public class Goblin : MonsterRace
    {
        public Goblin()
        {
            Name = nameof(Goblin);
            Description = "A sneaky theivish pest that lingers around settlements and lives within swamps";
            Biome = new Swamp();
        }
    }
}